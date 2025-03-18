using MethodAssessment.Controllers;
using MethodAssessment.Dto;
using MethodAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MethodAssessment.Test.Controllers;

public class AppControllerTest
{
    [Fact]
    public async Task GetStrings_ShouldReturn_Strings()
    {
        var controller = new AppController();
        var result = await controller.GetStrings();
        Assert.NotNull(result);
        if (result.Value != null) Assert.Equal(1000, result.Value.data.Length);
    }
    
    [Fact]
    public async Task Dynamic_GetStrings_InvalidPageSize_ReturnsBadRequest()
    {
        var controller = new AppController();
        var result = await controller.GetStrings(size: 0);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Page size must be between 1 and 1000.", badRequestResult.Value);
    }
    
    [Fact]
    public async Task Dynamic_GetStrings_ReturnsOkResult()
    {
        var controller = new AppController();
        var result = await controller.GetStrings(size: 10);
        Assert.NotNull(result);
        if (result.Value != null) Assert.Equal(10, result.Value.data.Length);
    }
    
    [Fact]
    public async Task Page_GetStrings_InvalidPageNumber_ReturnsBadRequest()
    {
        var controller = new AppController();
        var result = await controller.GetStrings(page: 0, size: 100);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Page number must be positive. (Parameter 'page')", badRequestResult.Value);
    }
    
    [Fact]
    public async Task Page_GetStrings_ValidInput_ReturnsOkResult()
    {
        var controller = new AppController();
        var result = await controller.GetStrings(page: 1, size: 100);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<PaginatedAppDto>(okResult.Value);
        Assert.Equal(1, returnValue.pageInfo.page);
        Assert.Equal(100, returnValue.pageInfo.size);
        Assert.Equal(100, returnValue.data.Length);
    }
    
    [Fact]
    public async Task Page_GetStrings_LastPage_ReturnsPartialPage()
    {
        var controller = new AppController();
        var result = await controller.GetStrings(page: 10, size: 100);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<PaginatedAppDto>(okResult.Value);
        Assert.Equal(10, returnValue.pageInfo.page);
        Assert.Equal(100, returnValue.pageInfo.size);
        Assert.True(returnValue.data.Length > 0 && returnValue.data.Length <= 100);
    }
}