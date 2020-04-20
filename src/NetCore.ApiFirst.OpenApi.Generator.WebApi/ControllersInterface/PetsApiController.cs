using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NetCore.ApiFirst.OpenApi.Generator.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace NetCore.ApiFirst.OpenApi.Generator.WebApi.ControllersInterface
{
   public abstract class PetsApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Creates a new pet in the store. Duplicates are allowed</remarks>
        /// <param name="newPet">Pet to add to the store</param>
        /// <response code="200">pet response</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [Route("/api/pets")]
        [SwaggerOperation("AddPet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Pet), description: "pet response")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public abstract IActionResult AddPet([FromBody]NewPet newPet);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>deletes a single pet based on the ID supplied</remarks>
        /// <param name="id">ID of pet to delete</param>
        /// <response code="204">pet deleted</response>
        /// <response code="0">unexpected error</response>
        [HttpDelete]
        [Route("/api/pets/{id}")]
        [SwaggerOperation("DeletePet")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public abstract IActionResult DeletePet([FromRoute][Required]long id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a user based on a single ID, if the user does not have access to the pet</remarks>
        /// <param name="id">ID of pet to fetch</param>
        /// <response code="200">pet response</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/api/pets/{id}")]
        [SwaggerOperation("FindPetById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Pet), description: "pet response")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public abstract IActionResult FindPetById([FromRoute][Required]long id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns all pets from the system that the user has access to Nam sed condimentum est. Maecenas tempor sagittis sapien, nec rhoncus sem sagittis sit amet. Aenean at gravida augue, ac iaculis sem. Curabitur odio lorem, ornare eget elementum nec, cursus id lectus. Duis mi turpis, pulvinar ac eros ac, tincidunt varius justo. In hac habitasse platea dictumst. Integer at adipiscing ante, a sagittis ligula. Aenean pharetra tempor ante molestie imperdiet. Vivamus id aliquam diam. Cras quis velit non tortor eleifend sagittis. Praesent at enim pharetra urna volutpat venenatis eget eget mauris. In eleifend fermentum facilisis. Praesent enim enim, gravida ac sodales sed, placerat id erat. Suspendisse lacus dolor, consectetur non augue vel, vehicula interdum libero. Morbi euismod sagittis libero sed lacinia.  Sed tempus felis lobortis leo pulvinar rutrum. Nam mattis velit nisl, eu condimentum ligula luctus nec. Phasellus semper velit eget aliquet faucibus. In a mattis elit. Phasellus vel urna viverra, condimentum lorem id, rhoncus nibh. Ut pellentesque posuere elementum. Sed a varius odio. Morbi rhoncus ligula libero, vel eleifend nunc tristique vitae. Fusce et sem dui. Aenean nec scelerisque tortor. Fusce malesuada accumsan magna vel tempus. Quisque mollis felis eu dolor tristique, sit amet auctor felis gravida. Sed libero lorem, molestie sed nisl in, accumsan tempor nisi. Fusce sollicitudin massa ut lacinia mattis. Sed vel eleifend lorem. Pellentesque vitae felis pretium, pulvinar elit eu, euismod sapien. </remarks>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <response code="200">pet response</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/api/pets")]
        [SwaggerOperation("FindPets")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Pet>), description: "pet response")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public abstract IActionResult FindPets([FromQuery]List<string> tags, [FromQuery]int limit);
    }
}