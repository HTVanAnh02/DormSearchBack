using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Areas;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Infrastructure.Context;
using DormSearchBe.Infrastructure.Settings;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DormSearchBe.Application.Service
{
    public class ThongkeService : IThongkeService
    {
        private readonly DormSearch_DbContext _context;
        public ThongkeService(DormSearch_DbContext context)
        {
            _context = context;
        }
        public DataResponse<Dictionary<string, int>> totalCity()
        {
            var dataDic = new Dictionary<string, int>();
            try
            {
                var citys = _context.Cities.Where(x => x.deletedAt == null).ToList();
                for(var i = 0; i < citys.Count; i++)
                {
                    var data = citys[i];
                    var checkHouse = _context.Houses.Where(x => x.CityId == data.CityId).Count();
                    dataDic.Add(data.CityName ?? "Thành phố không tên", checkHouse);
                }

                return new DataResponse<Dictionary<string, int>>(dataDic, HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            catch (Exception ex)
            {
                dataDic.Add(ex.Message, 1);
                return new DataResponse<Dictionary<string, int>>(dataDic, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        public DataResponse<Dictionary<string, long>> totalDienTich()
        {
            var data = new Dictionary<string, long>();

            try
            {
                var dataHouse = _context.Houses.Where(x => x.deletedAt == null).ToList();
                foreach(var house in dataHouse)
                {
                    if(house.Acreage == null || house.Acreage == "")
                    {
                        continue;
                    }

                    long so = 0L;
                    int check = 0;
                    
                    long number = 0L;
                    int tudau = 0;
                    int den = 0;

                    if (house.Acreage.Length >= 2)
                    {
                        if (long.TryParse(house.Acreage.Substring(0, 2), out long so0_2)) //"Substring(0, 2)" cắt chuỗi sử dụng hàm "Substring", "(0, 2)" nghĩa là cắt từ vị trí thứ 0 đến vị trí thứ 2 
                        {
                            so = long.Parse(house.Acreage.Substring(0, 2));
                            check = 1;

                            tudau = 0;
                            den = 2;
                        }
                        else
                        {
                            if (long.TryParse(house.Acreage.Substring(0, 1), out long so0_1))
                            {
                                check = 2;
                                so = so0_1;

                                tudau = 0;
                                den = 1;
                            }
                            else
                            {
                                if (long.TryParse(house.Acreage.Substring(1, 2), out long so1_2))
                                {
                                    check = 3;
                                    so = so1_2;

                                    tudau = 1;
                                    den = 2;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }

                    long sodem = so + 10;

                    if (!data.Any())
                    {
                        if (so >= long.Parse(house.Acreage.Substring(tudau, den)) && so <= sodem)
                        {
                            number++;
                            data.Add(house.Acreage, number);
                        }
                    }
                    else
                    {
                        //foreach (var keyvalue in data)
                        //{
                        //    int keyBuff = 0;
                        //    int buff10 = 0;
                        //    if (checkInt(keyvalue.Key) == check)
                        //    {
                        //        keyBuff = int.Parse(keyvalue.Key.Substring(tudau, den));
                        //        buff10 = keyBuff + 10;
                        //        if ((so >= keyBuff && so <= buff10) || data.ContainsKey(house.Acreage))
                        //        {
                        //            data[keyvalue.Key]++;
                        //        }
                        //        else
                        //        {
                        //            number++;
                        //            data.Add(house.Acreage, number);
                        //        }
                        //    }
                        //    else if (checkInt(keyvalue.Key) != check && checkInt(keyvalue.Key) != 0 && check != 0)
                        //    {
                                //var checkData = data.Where(x => int.Parse(x.Key.Substring(tudau, den)) <= int.Parse(Acreage.Substring(tudau, den)) && int.Parse(Acreage.Substring(tudau, den)) <= int.Parse(x.Key.Substring(tudau, den)) + 10).ToList();
                                //if (checkData.Any())
                                //{
                                //    data[keyvalue.Key]++;
                                //}
                        //        if (so >= long.Parse(house.Acreage.Substring(tudau, den)) && so <= sodem)
                        //        {
                        //            number++;
                        //            data.Add(house.Acreage, number);
                        //        }


                        //    }
                        //    else
                        //    {
                        //        continue;
                        //    }
                        //}
                        var checkData = updateData(data, check, tudau, den, (int)so, house.Acreage, (int)number, (int)sodem);
                        if(checkData != "Add" && checkData != "Faild")
                        {
                            data[checkData]++;
                        }
                        else if(checkData == "Add")
                        {
                            number++;
                            data.Add(house.Acreage, number);
                        }
                    }
                   
                }


                return new DataResponse<Dictionary<string, long>>(data, HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            catch(Exception ex)
            {
                data.Add(ex.Message, 1);
                return new DataResponse<Dictionary<string, long>>(data, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        private string updateData( Dictionary<string, long> data, int check, int tudau, int den, int so, string Acreage, int number, int sodem)
        {
            foreach (var keyvalue in data)
            {
                int keyBuff = 0;
                int buff10 = 0;
                if (checkInt(keyvalue.Key) == check)
                {
                    keyBuff = int.Parse(keyvalue.Key.Substring(tudau, den));
                    buff10 = keyBuff + 10;

                    if ((so >= keyBuff && so <= buff10) || data.ContainsKey(Acreage))
                    {
                        return keyvalue.Key;
                    }
                    else
                    {
                        return "Add";
                    }
                }
                else if (checkInt(keyvalue.Key) != check && checkInt(keyvalue.Key) != 0 && check != 0)
                {
                    var checkData = data.Where(x => int.Parse(x.Key.Substring(tudau, den)) <= int.Parse(Acreage.Substring(tudau, den)) && int.Parse(Acreage.Substring(tudau, den)) <= int.Parse(x.Key.Substring(tudau, den)) + 10).ToList();
                    if (checkData.Any())
                    {
                        return keyvalue.Key;
                    }
                    else
                    {
                        if (so >= long.Parse(Acreage.Substring(tudau, den)) && so <= sodem)
                        {
                            return "Add";
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            return "Faild";
        }

        private int checkInt(string value)
        {
            if (long.TryParse(value.Substring(0, 2), out long so0_2)) //"Substring(0, 2)" cắt chuỗi sử dụng hàm "Substring", "(0, 2)" nghĩa là cắt từ vị trí thứ 0 đến vị trí thứ 2 
            {
                return 1;
            }
            else
            {
                if (long.TryParse(value.Substring(0, 1), out long so0_1))
                {
                    return 2;
                }
                else
                {
                    if (long.TryParse(value.Substring(1, 2), out long so1_2))
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public DataResponse<Dictionary<string, long>> totalGiaTien()
        {
            var data = new Dictionary<string, long>();
            
            try
            {
                var dataSave = new Dictionary<string, long>();
                var dataPrice = _context.Houses.Where(x => x.deletedAt == null).ToList();

                for(int i = 0;  i < dataPrice.LongCount(); i++)
                {
                    var dataItemPrice = dataPrice[i];

                    if(!int.TryParse(dataItemPrice.Price, out int soInt))
                    {
                        continue;
                    }

                    var checkDataSave = dataSave.Where(x => int.Parse(x.Key) <= soInt && soInt <= int.Parse(x.Key) + 10000).ToList();
                    if (checkDataSave.Any())
                    {
                        data[soInt.ToString()]++;
                    }
                    else
                    {
                        int number = 0;
                        int bufff100000 = soInt + 100000;
                        int soNT = int.Parse(dataItemPrice.Price ?? "400000");
                        if(soNT >= soInt && soNT <= bufff100000)
                        {
                            number++;
                            data.Add(dataItemPrice.Price ?? "400000", number);
                            dataSave.Add(dataItemPrice.Price == null ? "45000" : dataItemPrice.Price, soInt);
                        }
                        
                    }
                }

                return new DataResponse<Dictionary<string, long>>(data, HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            catch(Exception ex)
            {
                data.Add(ex.Message, 1);
                return new DataResponse<Dictionary<string, long>>(data, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        public DataResponse<Dictionary<string, int>> totalMien()
        {
            var data = new Dictionary<string, int>();   
            try
            {
                var checkMien = _context.Areas.Where(x => x.deletedAt == null).ToList();
                for(int i = 0; i < checkMien.Count; i++)
                {
                    var dataItem = checkMien[i];
                    var checkHouse = _context.Houses.Where(x => x.AreasId == dataItem.AreasId).Count();
                    data.Add(dataItem.AreasName, checkHouse);
                }

                return new DataResponse<Dictionary<string, int>>(data, HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            catch (Exception ex)
            {
                data.Add(ex.Message, 1);
                return new DataResponse<Dictionary<string, int>>(data, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        public DataResponse<int> totalTongBaiDang()
        {
            try
            {
                var totalCout = _context.Houses.Where(x => x.deletedAt == null).ToList().Count();
                return new DataResponse<int>(totalCout, HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            catch(Exception ex)
            {
                return new DataResponse<int>(0, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }
    }
}
