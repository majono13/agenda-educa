namespace EducaApi.Application.DTOs
{
    public class PageBaseResponseDTO<T>
    {
        public int TotalRegisters { get; private set; }
        public List<T> Data { get; private set; }

        public PageBaseResponseDTO(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;
        }
    }
}
