﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Data.Repositories;
using ShopBuoi.Model.Models;
using System.Linq;

namespace ShopBuoi.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(8, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;            
            var result= objRepository.Add(category);
            unitOfWork.Commit();    
            Assert.IsNotNull(result);
            Assert.AreEqual(8, result.ID);
        }
    }
}