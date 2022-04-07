using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Bootcamp.API.Repositories;

namespace Bootcamp.API.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;
        private IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public ResponseDto<List<MovieDto>> GetAll()
        {

            var movies = _movieRepository.GetAll();
            var moviesDto =_mapper.Map<List<MovieDto>>(movies);
            return ResponseDto<List<MovieDto>>.Success(moviesDto, 200);
        }

        public ResponseDto<MovieDto> GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return ResponseDto<MovieDto>.Success(movieDto, 200);
        }

        public ResponseDto<NoContentDto> Add(Movie newMovie)
        {
            _movieRepository.Add(newMovie);
            return ResponseDto<NoContentDto>.Success(201);
        }


        public ResponseDto<NoContentDto> Update(Movie updateMovie)
        {

            var movie = _movieRepository.GetById(updateMovie.Id);
            _movieRepository.Update(updateMovie);
            return ResponseDto<NoContentDto>.Success(204);
        }
        public ResponseDto<NoContentDto> Delete(int id)
        {
            var hasProduct = _movieRepository.GetById(id);

            _movieRepository.Delete(id);

            return ResponseDto<NoContentDto>.Success(204);

        }

    }
}
