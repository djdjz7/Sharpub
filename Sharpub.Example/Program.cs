using Sharpub.Model;
using Sharpub.Model.Section;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Sharpub.Example
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var meta = new EpubMetadata("My ePub book", "en-US");
            var book = new EpubBook(meta);
            var chapterContent = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nulla facilisi morbi tempus iaculis urna id. Fusce id velit ut tortor pretium viverra suspendisse potenti nullam. Ut lectus arcu bibendum at varius vel. Egestas sed tempus urna et pharetra. In nisl nisi scelerisque eu ultrices vitae auctor. Eget mauris pharetra et ultrices neque ornare aenean. Rhoncus est pellentesque elit ullamcorper. Aliquam faucibus purus in massa tempor nec feugiat. Donec ultrices tincidunt arcu non sodales neque sodales ut etiam. Urna id volutpat lacus laoreet non curabitur gravida arcu. Consequat nisl vel pretium lectus quam id leo. Cras ornare arcu dui vivamus arcu felis bibendum ut. Sit amet justo donec enim diam vulputate ut pharetra sit.

Purus sit amet luctus venenatis lectus magna. Eleifend quam adipiscing vitae proin sagittis nisl rhoncus mattis. Amet nisl suscipit adipiscing bibendum est. Tellus at urna condimentum mattis pellentesque id. Vel risus commodo viverra maecenas accumsan lacus vel facilisis. Sit amet mattis vulputate enim. Tristique senectus et netus et malesuada fames. Sagittis eu volutpat odio facilisis mauris. Netus et malesuada fames ac turpis egestas integer. Elit duis tristique sollicitudin nibh sit amet commodo nulla facilisi. Morbi enim nunc faucibus a pellentesque sit. Quisque egestas diam in arcu cursus euismod quis viverra. Vel fringilla est ullamcorper eget nulla facilisi etiam dignissim. Venenatis a condimentum vitae sapien. Sit amet mattis vulputate enim nulla aliquet. Enim ut tellus elementum sagittis vitae et leo duis. Facilisis gravida neque convallis a cras semper auctor. Ultrices neque ornare aenean euismod elementum nisi quis eleifend.

Sapien eget mi proin sed libero. Tellus orci ac auctor augue mauris augue. Amet risus nullam eget felis. Parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer. Mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et. Vestibulum sed arcu non odio euismod lacinia at quis risus. Nulla aliquet porttitor lacus luctus. Elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Amet nulla facilisi morbi tempus. Lobortis elementum nibh tellus molestie nunc non blandit massa enim.

Mauris commodo quis imperdiet massa tincidunt nunc. Mi proin sed libero enim sed faucibus turpis. Platea dictumst quisque sagittis purus sit. Tempor commodo ullamcorper a lacus vestibulum sed. Dui vivamus arcu felis bibendum ut tristique et egestas quis. Mi ipsum faucibus vitae aliquet nec ullamcorper. Orci sagittis eu volutpat odio facilisis mauris sit amet. Vitae ultricies leo integer malesuada nunc vel risus. Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi. Nunc sed velit dignissim sodales ut eu. Augue eget arcu dictum varius duis at consectetur lorem donec. Porttitor lacus luctus accumsan tortor posuere. Cursus eget nunc scelerisque viverra.

Non blandit massa enim nec dui nunc mattis. Convallis aenean et tortor at risus viverra adipiscing at in. Et ultrices neque ornare aenean. Quis ipsum suspendisse ultrices gravida. Vitae congue eu consequat ac felis. Eget nunc lobortis mattis aliquam. Enim neque volutpat ac tincidunt. Nisl suscipit adipiscing bibendum est ultricies integer quis. Cursus in hac habitasse platea dictumst quisque. Vulputate mi sit amet mauris commodo quis imperdiet massa. Condimentum id venenatis a condimentum vitae. Turpis egestas integer eget aliquet. Nisl purus in mollis nunc. Integer quis auctor elit sed vulputate mi sit amet. Fermentum et sollicitudin ac orci phasellus egestas tellus rutrum. Faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper. Neque gravida in fermentum et sollicitudin ac.";
            book.AddChapter(
                new Chapter(
                    "Introduction",
                    new List<ISection>() { new SubChapter("First sub-chapter", chapterContent) }
                )
            );
            await book.ExportAsync("1.zip");
        }
    }
}
