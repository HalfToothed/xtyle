using System.Runtime.ExceptionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Completions;
using Microsoft.AspNetCore.Mvc;



namespace xtyle_backend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class OpenAiController : ControllerBase
    {
    
        [HttpGet("Get")]
        public async Task<IActionResult> CallApi()
        {
            var OpenAIkey = "";
            APIAuthentication aPIAuthentication = new APIAuthentication(OpenAIkey);

            OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);

            try
            {
                string prompt = "what is euler's equation";
                string model = "text-davinci-003";
                int maxTokens = 50;

                var completionRequest = new CompletionRequest
                {
                    Prompt = prompt,
                    Model = model,
                    MaxTokens = maxTokens
                };

                return Ok(await openAiApi.Completions.CreateCompletionAsync(completionRequest));
                // var generatedText = completionResult.Completions[0].Text; //completionResult.Choices[0].Text.Trim();
                
                // return generatedText;

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }        

        }        
       
    }

