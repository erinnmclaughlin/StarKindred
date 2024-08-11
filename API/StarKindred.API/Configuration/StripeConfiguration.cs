namespace StarKindred.API.Configuration;

public static class StripeConfiguration
{
    public static void AddAndConfigureStripe(this WebApplicationBuilder builder)
    {
        var stripeConfiguration = builder.Configuration.GetSection("Stripe");
        if (stripeConfiguration.Exists())
        {
            Stripe.StripeConfiguration.ApiKey = stripeConfiguration.GetSection("ApiKey").Get<string>()
                ?? throw new Exception("Stripe:ApiKey is missing from configuration.");
        }
    }
}
