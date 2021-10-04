using System;
using System.IO;
using Xunit;
using Program;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var action = new Subtitles();
            action.set_input("../../../../legenda.srt");
            action.set_output("../../../../testee.srt");
            action.times.set_signal(1);
            action.times.set_time(1,1);
            action.times.set_time(2,2);
            action.times.set_time(3,3);
            action.times.set_time(4,4);
            action.times.set_time(5,0);
            int ret = action.read_file();
            Assert.Equal(ret, 1);
        }
    }
}
