using DesignPatterns;

namespace Entities.Workers
{
    public class Worker : Composite
    {
        public WorkerSO Data;

        public Worker(WorkerSO data)
        {
            Data = data;
        }
    }
}