using _4Create.Application.Members.CreateEmployee;
using _4Create.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace _4Create.Application.UnitTests.Members.CreateCompany;

public class CreateEmployeeCommandHandlerTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepoMock;
    private readonly Mock<ICompanyService> _companyServiceMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CreateEmployeeCommandHandlerTests()
    {
        _companyServiceMock = new();
        _employeeRepoMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenEmailsIsNotUnique()
    {
        // Arrange
        var command = new CreateEmployeeCommand(
            "test@test.com",
            Domain.Enums.Title.Developer,
            new List<Guid>());

        _employeeRepoMock.Setup(
            x => x.IsEmailUnique(
                It.IsAny<string>()))
            .Returns(false);

        var handler = new CreateEmployeeCommandHandler(
            _employeeRepoMock.Object,
            _unitOfWorkMock.Object,
            _companyServiceMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
    }
}
