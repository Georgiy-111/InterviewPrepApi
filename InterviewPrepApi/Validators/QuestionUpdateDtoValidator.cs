using FluentValidation;
using InterviewPrepApi.DTOs;

namespace InterviewPrepApi.Validators;

public class QuestionUpdateDtoValidator : AbstractValidator<QuestionUpdateDto>
{
    public QuestionUpdateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Текст вопроса обязателен")
            .MaximumLength(1000).WithMessage("Текст вопроса не должен превышать 1000 символов");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Ответ обязателен")
            .MaximumLength(5000).WithMessage("Ответ не должен превышать 5000 символов");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Категория обязательна")
            .MaximumLength(100).WithMessage("Категория не должна превышать 100 символов");

        RuleFor(x => x.Difficulty)
            .InclusiveBetween(1, 5).WithMessage("Сложность должна быть от 1 до 5");
    }
}