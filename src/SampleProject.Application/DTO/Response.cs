namespace SampleProject.Application.DTO
{
    public abstract class Response<TStruct> where TStruct : struct
    {
        public TStruct Id { get; set; }
    }
}
