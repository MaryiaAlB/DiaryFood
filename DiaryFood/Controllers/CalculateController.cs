using DiaryFood.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DiaryFood.Controller;

[ApiController]
[Route("api/[controller]")]
    public class CalculateController : ControllerBase
    {

    [HttpGet]
    public string CalculateBZU(string gender, string goal, double weight, int height, int age, double activity, string formula)
    {
        CalculateService calc = new CalculateService(gender, goal, weight, height, age, activity);
        if (formula == "Миффлина-Сан-Жеора")
        {
            calc.CalculateMafSanZh();
        }
        else calc.CalculateHarBened();

        return $"Твои параметры: калории {calc.Calories} ккал, белки: {calc.Protein} г, жиры: {calc.Fat} г, углеводы: {calc.Carbs} г";
    }

}

