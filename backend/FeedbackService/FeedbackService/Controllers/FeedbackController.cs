using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FeedbackService.Models;
using FeedbackService.Services;

namespace FeedbackService.Controllers
{
    public class FeedbackController : ApiController
    {
        private PostService postService=new PostService();
        private CommentService commentService=new CommentService();
        [Route("api/feedback/allpost")]
        public IHttpActionResult GetAllPosts(int skip,int take)
        {
            var posts = postService.GetAllPost(skip,take);
            return Ok(posts);
        }
        [Route("api/feedback/getlikes/{commentId}")]
        public IHttpActionResult GetLikeCountByCommentId(long commentId)
        {
            int likeCount = commentService.GetLikeCountByCommentId(commentId);
            return Ok(likeCount);
        }
        [Route("api/feedback/getdislikes/{commentId}")]
        public IHttpActionResult GetDisLikeCountByCommentId(long commentId)
        {
            int disLikeCount = commentService.GetDisLikeCountByCommentId(commentId);
            return Ok(disLikeCount);
        }
        [Route("api/feedback/like/{userId}/{commentId}")]
        public IHttpActionResult AddLike(long userId,long commentId)
        {
            int disLikeCount = commentService.UpdateLikes(userId,commentId);
            return Ok(disLikeCount);
        }
        [Route("api/feedback/dislike/{userId}/{commentId}")]
        public IHttpActionResult AddDislike(long userId, long commentId)
        {
            int disLikeCount = commentService.UpdateDisLikes(userId,commentId);
            return Ok(disLikeCount);
        }
    }
}
