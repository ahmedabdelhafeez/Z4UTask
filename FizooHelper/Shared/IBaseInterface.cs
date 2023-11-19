using FizooHelper.Models;
namespace FizooHelper.Shared
{
    public interface IBaseInterface<AddDto,GetDto,GetAllDto,UpdateDto, DeleteDto> : IBaseAddInterface<AddDto>, IBaseGetInterface<GetDto>, IBaseGetAllInterface<GetAllDto>, IBaseDeleteInterface<DeleteDto>, IBaseUpdateInterface<UpdateDto>
    {
    }    
    public interface IBaseAddInterface<AddDTO>
    {
        Task<Respond<AddDTO>> Add(AddDTO dto);
    }
    public interface IBaseGetInterface<GetDto>
    {
        Task<Respond<GetDto>> Get(int id);
    }   
    public interface IBaseGetAllInterface<GetAllDto>
    {
        Task<GetAllDto> GetAll(FilterModel?filter=null);
    }
    public interface IBaseDeleteInterface<deleteDto>
    {
        Task<Respond<deleteDto>> Delete(int id);
    }
    public interface IBaseUpdateInterface<dto>
    {
        Task<Respond<dto>> Update(int id, dto dto);
    }
}

