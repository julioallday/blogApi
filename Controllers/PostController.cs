using AutoMapper;
using blogApi.Data;
using blogApi.Data.Dtos;
using blogApi.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace blogApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class PostController : ControllerBase
{
    private PostContext _context;
    private IMapper _mapper;
    public PostController(PostContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreatePostDto postDto)
    {
        Post post = _mapper.Map<Post>(postDto);
        _context.Posts.Add(post);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadPostById), new { id = post.Id }, post);

    }
    [HttpGet]
    public IEnumerable<Post> ReadPosts([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _context.Posts.Skip(skip).Take(take);
    }
    [HttpGet("{id}")]
    public IActionResult ReadPostById(int id)
    {
        var post = _context.Posts.FirstOrDefault(post => post.Id == id);
        if (post == null) return NotFound();
        return Ok(post);
    }
    [HttpPut("{id}")]
    public IActionResult UpdatePost(int id, [FromBody]
      UpdatePostDto postDto)
    {
        var post = _context.Posts.FirstOrDefault(
         post => post.Id == id);
        if (post == null) NotFound();
        _mapper.Map(postDto, post);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateParcialPost(int id, JsonPatchDocument<UpdatePostDto> patch)
    {
        var post = _context.Posts.FirstOrDefault(
         post => post.Id == id);
        if (post == null) NotFound();
        var postForUpdate = _mapper.Map<UpdatePostDto>(post);
        patch.ApplyTo(postForUpdate, ModelState);
        if (!TryValidateModel(postForUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(postForUpdate, post);
        _context.SaveChanges();
        return NoContent();
    }
}