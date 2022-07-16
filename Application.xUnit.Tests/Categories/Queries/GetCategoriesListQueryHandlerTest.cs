using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Domain.Entities;
using Application.Contracts.Persistence;
using Application.Profiles;
using Application.xUnit.Tests.Mocks;
using System.Threading;
using Application.Features.Categories.Queries.GetCategoriesList.VM;
using Application.Features.Categories.Queries.GetCategoriesList;
using Shouldly;

namespace Application.xUnit.Tests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTest()
        {
            //instantiate Repository(Mock)
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            
            // instantiate autoMapper
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_CategoriesList_Test()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
