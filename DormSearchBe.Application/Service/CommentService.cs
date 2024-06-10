using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Areas;
using DormSearchBe.Domain.Dto.Comment;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Infrastructure.Context;
using DormSearchBe.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.Service
{
    public class CommentService : ICommentService
    {
        private readonly DormSearch_DbContext _context;
        public CommentService(DormSearch_DbContext context)
        {
            _context = context;   
        }

        public DataResponse<commentDescriptionDTO> CreateCommenDescriptiont(commentDescriptionDTO commentDescriptionDTOs)
        {
            try
            {
                var checkUser = _context.Users.Where(x => x.UserId == Guid.Parse(commentDescriptionDTOs.account_ID.ToUpper())).FirstOrDefault();
                if (checkUser == null)
                {
                    return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Account Null" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                }

                if (string.IsNullOrEmpty(commentDescriptionDTOs.commentDescriptionReps_ID) && string.IsNullOrEmpty(commentDescriptionDTOs.commentDescription_ID))
                {
                    var checkComment = _context.Comments.Where(x => x.Id == Guid.Parse(commentDescriptionDTOs.comment_ID.ToUpper())).FirstOrDefault();
                    if(checkComment == null)
                    {
                        return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Commemt Null" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                    }

                    var commentDescript = new CommentDescription
                    {
                        Id = Guid.NewGuid(),
                        Message = commentDescriptionDTOs.message,
                        Id_Commnet = checkComment.Id,
                        comments = checkComment,
                        UserId = checkUser.UserId,
                        Account = checkUser,
                        createdAt = DateTime.Now
                    };

                    _context.CommentDescriptions.Add(commentDescript);
                    if(_context.SaveChanges() > 0)
                    {
                        return new DataResponse<commentDescriptionDTO>(commentDescriptionDTOs, HttpStatusCode.OK, HttpStatusMessages.OK);
                    }
                    return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Add Faild" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                }

                if(string.IsNullOrEmpty(commentDescriptionDTOs.comment_ID) && string.IsNullOrEmpty(commentDescriptionDTOs.commentDescriptionReps_ID))
                {
                    var checkCommentDescription = _context.CommentDescriptions.Where(x => x.Id == Guid.Parse(commentDescriptionDTOs.commentDescription_ID.ToUpper())).FirstOrDefault();
                    if(checkCommentDescription == null)
                    {
                        return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "CommentDescription Null" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                    }

                    var dataDesc = new CommentDescription
                    {
                        Id = Guid.NewGuid(),
                        Message = commentDescriptionDTOs.message,
                        UserId = checkUser.UserId,
                        RepComment2 = checkCommentDescription.Id,
                        Account = checkUser,
                        RepComment2s = checkCommentDescription,
                        createdAt = DateTime.Now,

                    };

                    _context.CommentDescriptions.Add(dataDesc);
                    if(_context.SaveChanges() > 0)
                    {
                        return new DataResponse<commentDescriptionDTO>(commentDescriptionDTOs, HttpStatusCode.OK, HttpStatusMessages.OK);
                    }

                    return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Add CommemntDescription Faild" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                }

                if(string.IsNullOrEmpty(commentDescriptionDTOs.comment_ID) && !string.IsNullOrEmpty(commentDescriptionDTOs.commentDescriptionReps_ID) && !string.IsNullOrEmpty(commentDescriptionDTOs.commentDescription_ID))
                {
                    var checkDataRep2 = _context.CommentDescriptions.Where(x => x.Id == Guid.Parse(commentDescriptionDTOs.commentDescription_ID.ToUpper())).FirstOrDefault();
                    var checkDataRep3 = _context.CommentDescriptions.Where(x => x.Id == Guid.Parse(commentDescriptionDTOs.commentDescriptionReps_ID.ToUpper())).FirstOrDefault();

                    if(checkDataRep2 == null || checkDataRep3 == null) {
                        return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Id CommemntDescription Null" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                    }

                    var dataComemntDescRep = new CommentDescription
                    {
                        Id = Guid.NewGuid(),
                        Message = commentDescriptionDTOs.message,
                        RepComment2 = checkDataRep2.Id,
                        RepComment3_N = checkDataRep3.Id,
                        UserId = checkUser.UserId,
                        Account = checkUser,
                        RepComment2s = checkDataRep2,
                        createdAt = DateTime.Now
                    };

                    _context.CommentDescriptions.Add(dataComemntDescRep);
                    if(_context.SaveChanges() > 0)
                    {
                        return new DataResponse<commentDescriptionDTO>(commentDescriptionDTOs, HttpStatusCode.OK, HttpStatusMessages.OK);
                    }

                    return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Add CommentDescription Rep Faild" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                }

                return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = "Add CommentDescription Rep Faild" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
            catch(Exception ex)
            {
                return new DataResponse<commentDescriptionDTO>(new commentDescriptionDTO { message = ex.Message }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        public DataResponse<CommentDTO> CreateComment(CommentDTO comment)
        {
            try {
                var checkUser = _context.Users.Where(x => x.UserId == Guid.Parse(comment.account_id.ToUpper())).FirstOrDefault();
                var checkHouse = _context.Houses.Where(x => x.HousesId == Guid.Parse(comment.houseproduct_id.ToUpper())).FirstOrDefault();
                if(checkUser == null || checkHouse == null)
                {
                    return new DataResponse<CommentDTO>(new CommentDTO { message = "Account Null" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
                }

                var commentData = new Comment
                {
                    Id = Guid.NewGuid(),
                    Message = comment.message,
                    accountId = checkUser.UserId,
                    HousesId = checkHouse.HousesId,
                    createdAt = DateTime.Now,
                    Account = checkUser,
                    Houses = checkHouse
                };

                _context.Comments.Add(commentData);
                if(_context.SaveChanges() > 0)
                {
                    return new DataResponse<CommentDTO>(comment, HttpStatusCode.OK, HttpStatusMessages.OK);
                }
                
                return new DataResponse<CommentDTO>(new CommentDTO { message = "Add Comment Faild" }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
            catch(Exception ex)
            {
                return new DataResponse<CommentDTO>(new CommentDTO { message = ex.Message }, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }

        public DataResponse<object> FindAll(string id)
        {
            try
            {
                var data = _context.Comments.Include(a => a.Account).Include(h => h.Houses).Include(d => d.commentDescriptions).ThenInclude(ad => ad.Account).Where(x => x.HousesId == Guid.Parse(id.ToUpper())).Select(x => new
                {
                    Id1 = x.Id,
                    Message1 = x.Message,
                    User = x.Account.Email,
                    Houses = x.Houses.HousesName,
                    Image = x.Account.Avatar,
                    CreateAt = x.createdAt,
                    CommentDescriptions = x.commentDescriptions.Select(d => new
                    {
                        Id2 = d.Id,
                        Message2 = d.Message,
                        User2 = d.Account.Email,
                        Image = d.Account.Avatar,
                        CreateAt = d.createdAt,
                        CommentDescriptionRep = d.commentDescriptions.Where(x => x.RepComment2 == d.Id).Select(d3 => new
                        {
                            Id3 = d3.Id,
                            Message3 = d3.Message,
                            User3 = d3.Account.Email,
                            Image = d3.Account.Avatar,
                            CreateAt = d3.createdAt,
                        }).OrderByDescending(x => x.CreateAt).ToList(),
                    }).OrderByDescending(x => x.CreateAt).ToList(),
                }).OrderByDescending(x => x.CreateAt).ToList();

                return new DataResponse<object>(data, HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            catch(Exception ex)
            {
                return new DataResponse<object>(ex.Message, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
            }
        }
    }
}
