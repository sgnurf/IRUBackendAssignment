using System.IO;
using System.Threading.Tasks;

namespace IReckonUAssignment.Logic
{
    public interface IProductFileProcessor
    {
        Task ProcessProductFile(Stream productFile);
    }
}