using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MovieStore.Pages;

public class Index_Tests : MovieStoreWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
