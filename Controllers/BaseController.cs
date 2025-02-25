using Microsoft.AspNetCore.Mvc;

namespace StudentCenterApi.Controllers;

public abstract class BaseController : ControllerBase
{
    protected BaseController() { }

    protected new ActionResult Sucess(object result, bool isUpdate = false)
    {
        return Ok(new
        {
            success = true,
            message = isUpdate ? "successfully updated" : "successfully created",
            data = result
        });
    }

    protected new ActionResult Sucess(string msg)
    {
        return Ok(new
        {
            success = true,
            message = msg
        });
    }

    protected new ActionResult Error(Exception ex)
    {
        if (ex.InnerException == null)
        {
            return Ok(new
            {
                success = false,
                message = ex.Message
            });
        }

        return Ok(new
        {
            success = false,
            message = ex.InnerException.InnerException.Message
        });
    }

    protected new ActionResult Error(string erro)
    {
        return Ok(new
        {
            success = false,
            message = erro
        });
    }
}
