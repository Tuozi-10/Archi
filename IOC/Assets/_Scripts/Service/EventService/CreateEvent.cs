namespace Service
{
    public class CreateEvent
    {
        public TypeWorker TypeWorker;
        
        public CreateEvent(TypeWorker typeWorker)
        {
            TypeWorker = typeWorker;
        }
    }

    public enum TypeWorker
    {
        LUMBERJACK,
        HARVESTER
    }
}