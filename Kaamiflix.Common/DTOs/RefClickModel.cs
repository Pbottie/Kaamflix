namespace Kaamiflix.Common.DTOs;
public record RefClickModel<TDto>(string PageType, TDto dto) where TDto: class;