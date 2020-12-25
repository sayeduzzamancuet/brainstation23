using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using AutoMapper;
using FeedbackService.Models;

namespace FeedbackService.Services
{
    public class CommentService
    {
        Mapper mapper;
        public CommentService()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<tblComment>, List<CommentsDTO>>());
            mapper = new Mapper(config);
        }

        public List<CommentsDTO> GetCommentsByPostId(long postId)
        {
            List<CommentsDTO> commentList;
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var comments = entities.tblComments.Where(x=>x.postId==postId);
                commentList = mapper.DefaultContext.Mapper.Map<List<CommentsDTO>>(comments);
            }
            return commentList;
        }
        public int GetLikeCountByCommentId(long commentId)
        {
            int likeCount=0;
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var likeNumber = entities.tblFeedbacks.Count(x => x.commentId == commentId && x.isLiked==true);
                likeCount = likeNumber != null ? (int)likeNumber : 0;
            }
            return likeCount;
        }
        public int GetDisLikeCountByCommentId(long commentId)
        {
            int disLikeCount = 0;
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var disLikeNumber = entities.tblFeedbacks.Count(x => x.commentId== commentId && x.isDisliked==true);
                disLikeCount = disLikeNumber != null ? (int)disLikeNumber : 0;
            }
            return disLikeCount;
        }
        public int UpdateLikes(long userId ,long commentId)
        {
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var feedback = entities.tblFeedbacks.SingleOrDefault(x => x.userId == userId && x.commentId==commentId);
                if (feedback.isLiked==true)
                {
                    feedback.isLiked = false;

                }
                else
                {
                    feedback.isLiked=true;
                }
                  
               
                entities.SaveChanges();

            }
            return GetLikeCountByCommentId(commentId);
        }
        
        public int UpdateDisLikes(long userId, long commentId)
        {
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var feedback = entities.tblFeedbacks.SingleOrDefault(x => x.userId == userId && x.commentId == commentId);
                if (feedback.isDisliked == true)
                {
                    feedback.isDisliked = false;

                }
                else
                {
                    feedback.isDisliked = true;
                }


                entities.SaveChanges();

            }
            return GetDisLikeCountByCommentId(commentId);
        }
    }
}