using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FeedbackService.Models;

namespace FeedbackService.Services
{
    public class PostService
    {
        Mapper mapper;
        public PostService()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<tblPost>, List<PostDTO>>());
             mapper = new Mapper(config);
        }
        public List<PostDTO> GetAllPost(int skip,int take)
        {
            List<PostDTO>postList=new List<PostDTO>();
            using (feedbackdbEntities entities = new feedbackdbEntities())
            {
                var posts = entities.tblPosts.ToList().Skip(skip).Take(take);
                postList = mapper.DefaultContext.Mapper.Map<List<PostDTO>>(posts);
            }
            return postList;
        }
        
    }
}