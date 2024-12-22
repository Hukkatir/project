using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace BuisnessLogic.Tests
{
    public class UserServiceTest
    {

        public readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }


        [Fact]
        public async void CreateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewUser_ShouldCreateNewUser()
        {
            var newUser = new User()
            {
                Username = "hukkatir",
                UserPassword = "",
                Email = "",
                FirstName = "",
                LastName = "",
                DateOfBirth = DateTime.MaxValue

            };

            // act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(newUser));
            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }


        public static IEnumerable<object[]> GetIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] { new User { Username = "", UserPassword = "", Email = "", FirstName = "", LastName = "", DateOfBirth = DateTime.MaxValue } },
                new object[] { new User { Username = "", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.MaxValue }  },
                new object[] { new User { Username = "hukkatir", UserPassword = "", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.MaxValue }  },
                new object[] { new User { Username = "hukkatir", UserPassword = "Qwerty123!", Email = "", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.MaxValue }  },
                new object[] { new User { Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "", LastName = "Дудина", DateOfBirth = DateTime.MaxValue }  },
                new object[] { new User { Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "", DateOfBirth = DateTime.MaxValue }  },

            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUser))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            var newUser = user;
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async void CreateAsyncNewUserShoutdCreateNewUser()
        {
            var example = new User()
            {
                Username = "hukkatir",
                UserPassword = "Qwerty123!",
                Email = "hukkatir@gmail.com",
                FirstName = "Соня",
                LastName = "Дудина",
                DateOfBirth = new DateTime(2006, 6, 1)

            };

            await service.Create(example);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }


        public static IEnumerable<object[]> UpdateIncorrectUser()
        {
            return new List<object[]>
            {
                // Пустой Username
                new object[] { new User { UserId = 1, Username = "", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // Пустой UserPassword
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // Пустой Email
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // Пустой FirstName
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // Пустой LastName
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // Все поля пустые
                new object[] { new User { UserId = 1, Username = "", UserPassword = "", Email = "", FirstName = "", LastName = "", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // DateOfBirth в будущем
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // CreatedDateTime в будущем
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now.AddDays(1), UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // UpdatedDateTime в будущем
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now.AddDays(1), UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
                // DeletedDateTime в будущем
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatir@gmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = DateTime.Now.AddDays(1) } },
                // Некорректный формат Email 
                new object[] { new User { UserId = 1, Username = "hukkatir", UserPassword = "Qwerty123!", Email = "hukkatirgmail.com", FirstName = "Соня", LastName = "Дудина", DateOfBirth = DateTime.Now.AddDays(-1), CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, UpdatedBy = 1, DeletedBy = null, DeletedDateTime = null } },
            };
        }

        [Fact]
        public async void UpdateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(UpdateIncorrectUser))]
        public async Task UpdateAsync_NewUser_ShouldNotCreateNewUser(User model)
        {
            var example = model;

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => service.Update(example));

            Assert.IsType<ArgumentException>(ex);

            userRepositoryMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingUser_ShouldThrowException()
        {
            var userId = 999;
            userRepositoryMoq.Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(new List<User>());

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetById(userId));
        }


        [Fact]
        public async void GetByIdAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Delete(It.IsAny<User>()), Times.Never);
        }
    }
}
