using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Filters;
using Bootcamp.API.Models;
using Bootcamp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;
        public MoviesController(MovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [CustomExceptionFilter]
        [ServiceFilter(typeof(CustomAuthorizationFilter))]
        [ServiceFilter(typeof(CacheResourceFilter))]
        public IActionResult GetProducts()
        {
            var result = _movieService.GetAll();

            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult AddMovie(MovieRequestDto newMovie)
        {
            var movie = _mapper.Map<Movie>(newMovie);
            var result = _movieService.Add(movie);
            if (result.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            else
            {
                return new ObjectResult(result) { StatusCode = result.StatusCode };
            }
        }

        [ServiceFilter(typeof(NotFoundMovieFilter))]
        [CustomExceptionFilter]
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updateMovie)
        {
            var result = _movieService.Update(updateMovie);


            if (result.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            else
            {
                return new ObjectResult(result) { StatusCode = result.StatusCode };
            }

        }

        [ServiceFilter(typeof(NotFoundMovieFilter))]
        [CustomExceptionFilter]
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _movieService.Delete(id);


            if (result.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            else
            {
                return new ObjectResult(result) { StatusCode = result.StatusCode };
            }
        }

    }
}
