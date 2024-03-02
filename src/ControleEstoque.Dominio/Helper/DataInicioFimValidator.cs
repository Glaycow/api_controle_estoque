using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Dominio.Helper;

public class DataInicioFimValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        var dataInicio = (DateTime)validationContext.ObjectInstance.GetType().GetProperty("DataInicio").GetValue(validationContext.ObjectInstance);
        var dataFim = (DateTime)value;

        return dataFim < dataInicio ? new ValidationResult("Data de fim deve ser posterior à data de início") : ValidationResult.Success;
    }
}