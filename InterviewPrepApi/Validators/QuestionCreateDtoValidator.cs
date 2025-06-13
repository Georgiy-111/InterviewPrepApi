using FluentValidation;
using InterviewPrepApi.DTOs;

namespace InterviewPrepApi.Validators;

public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
{
    public QuestionCreateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Вопрос не должен быть пустим")
            .MaximumLength(1000).WithMessage("Текст вопроса не должен превышать 1000 символов");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Ответ обязателен")
            .MaximumLength(5000).WithMessage("Ответ не должен превышать 5000 символов");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Категория обязательна");

        RuleFor(x => x.Difficulty)
            .NotNull().WithMessage("Поле 'Сложность' обязательно");

        RuleFor(x => x.Difficulty)
            .InclusiveBetween(1, 5).WithMessage("Сложность должна быть от 1 до 5");
    }
}