using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCateogry;
using Application.Features.Categories.Commands.CreateCateogry.Response;
using Application.Profiles;
using Application.xUnit.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.xUnit.Tests.Categories.Commmands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTest()
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
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new CreateCategoryCommand() { Name="testxUnit Cat"}, CancellationToken.None);

            result.ShouldBeOfType<CreateCategoryCommandResponse>();


            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            allCategories.Count.ShouldBe(5);
        }
    }
}
