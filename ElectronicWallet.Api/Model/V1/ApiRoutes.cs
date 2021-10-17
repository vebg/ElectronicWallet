

namespace ElectronicWallet.Api.Model.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Users
        {
            public const string Update = Base + "/users/{userId}";
            public const string Delete = Base + "/users/{userId}";
            public const string Get = Base + "/users/{userId}";
            public const string Create = Base + "/users";
            public const string GetAll = Base + "/users";

        }

        public static class Authentication
        {
            public const string Login = Base + "/users/login";
            public const string LogOut = Base + "/users/logout";
        }

        public static class Wallets
        {
            public const string Create = Base + "/wallets/{userId}";
            public const string AddBalance = Base + "/wallets/{walletId}/users/{userId}/balance";
        }

        public static class UsersWallets
        {
            public const string GetAll = Base + "/users/{userId}/wallets";
            public const string Get = Base + "/users/{userId}/wallets/{walletId}";
            // public const string TransferMoney = Base + "/users/{userId}/wallets/{walletId}/transfer";
        }
/*
        public static class Orders
        {
            public const string Get = Base + "/orders/{orderId}";
            public const string GetOrdersByWallet = Base + "/orders/wallets/{walletId}";
        }

        public static class Payments
        {
            public const string PayService = Base + "/payments/services/{serviceId}";

        }*/

    }
}
