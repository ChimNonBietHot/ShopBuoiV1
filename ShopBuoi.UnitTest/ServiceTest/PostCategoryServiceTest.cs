using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Data.Repositories;
using ShopBuoi.Model.Models;
using ShopBuoi.Service;
using System.Collections.Generic;

namespace ShopBuoi.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            listCategory = new List<PostCategory>()
            {
             new PostCategory(){ID=1,Name="DM1",Status=true},
             new PostCategory(){ID=2,Name="DM2",Status=true},
            new PostCategory() { ID = 3, Name = "DM3", Status = true },
            };
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setupmethod
            _mockRepository.Setup(m => m.GetAll(null)).Returns(listCategory);
            //call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void PostCategory_Service_create()
        {
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test";
            category.Alias = "Test";
            category.Status = true;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
              {
                  p.ID = 1;
                  return p;
              });

            var result = _categoryService.Add(category);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}