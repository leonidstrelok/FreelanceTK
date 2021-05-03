namespace FreelanceTK.Application.Common.Constants
{
    public class LocalizationKeys
    {
        /// <summary>
        /// Общие ключи локализации
        /// </summary>
        public static class SharedKeys
        {
            /// <summary>
            /// Ошибка обработки зависимых данных. Проверьте правильность заполнения
            /// </summary>
            public const string CascadeDependencyError = "SK_CascadeDependencyError";

            /// <summary>
            /// Статус должен быть активным
            /// </summary>
            public const string StatusMustBeActive = "SK_StatusMustBeActive";
            /// <summary>
            /// Обнаружена циркулярная вложенность. Проверьте правильность заполнения данных.
            /// </summary>
            public const string CircularNesting = "SK_CircularNesting";
            /// <summary>
            /// Значение уже существует
            /// </summary>
            public const string ValueAlreadyExists = "SK_ValueAlreadyExists";
            /// <summary>
            /// Проверьте правильность данных.
            /// </summary>
            public const string EntityWithKeyDoesNotExists = "SK_EntityWithKeyDoesNotExists";
            /// <summary>
            /// Нельзя удалять запись, так как она уже используется.
            /// </summary>
            public const string HasOneOreMoreDependencies = "SK_HasOneOreMoreDependencies";

        }
    }
}
