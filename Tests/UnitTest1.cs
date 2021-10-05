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
            action.set_input("../../../../subtitle.srt");
            action.set_output("../../../../out.srt");
            action.times.set_signal(1);
            action.times.set_time(1,1);
            action.times.set_time(2,2);
            action.times.set_time(3,3);
            action.times.set_time(4,4);
            action.times.set_time(5,0);
            int ret = action.read_file();
            Assert.Equal(1, ret);
        }

        
        [Fact]
        public void valid_file()
        {
            var action = new Subtitles();
            var ret = action.set_input("../../../../subtitle.srt");
            Assert.Equal(1, ret);
        }

        [Fact]
        public void invalid_file()
        {
            var action = new Subtitles();
            var ret = action.set_input("../../../../legendas.srt");
            Assert.Equal(0, ret);
        }

        [Fact]
        public void valid_output()
        {
            var action = new Subtitles();
            var ret = action.set_output("out2.srt");
            Assert.Equal(1, ret);
        }

        [Fact]
        public void empty_output()
        {
            var action = new Subtitles();
            var ret = action.set_output("");
            Assert.Equal(0, ret);
        }

        [Fact]
        public void compar_file()
        {
            string text = System.IO.File.ReadAllText(@"../../../../subtitle.srt");
            string text2 = System.IO.File.ReadAllText(@"../../../../out2.srt");
            Assert.Equal(text, text2);
        }
        
    }
}
