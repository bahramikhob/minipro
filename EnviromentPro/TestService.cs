using Microsoft.Extensions.Options;

namespace EnviromentPro
{
    public class TestService
    {
        public TestService(IOptions<sitesetting1> options, IOptionsSnapshot<sitesetting1> optionsSnapshot )
        {
            var sitename = options.Value.sitename;
            var sitename1 = optionsSnapshot.Value.sitename;
        }

        public void Get()
        {
            
            //throw new NotImplementedException();
        }
    }
}
