namespace Merchello.UkFest.Web
{
    using System;
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.Core.Services;
    using Merchello.UkFest.Web.Resolvers;
    using Merchello.Web.Models.VirtualContent;

    using Umbraco.Core;
    using Umbraco.Core.Events;
    using Umbraco.Core.Models;
    using Umbraco.Core.Services;
    using Umbraco.Web;

    /// <summary>
    /// The Umbraco application event handler.
    /// </summary>
    public class UmbracoApplicationEventHandler : ApplicationEventHandler
    {
        /// <summary>
        /// Registers event handlers.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The <see cref="UmbracoApplication"/>.
        /// </param>
        /// <param name="applicationContext">
        /// The <see cref="ApplicationContext"/>.
        /// </param>
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Saving += ContentServiceOnSaving;
            ContentService.Saved += ContentServiceOnSaved;
            ContentService.Deleted += ContentServiceOnDeleted;

            // Merchello
            StoreSettingService.Saved += StoreSettingServiceOnSaved;
            ProductContentFactory.Initializing += ProductContentFactoryOnInitializing;
        }


        /// <summary>
        /// Set auto-properties on content saving
        /// We can't do these properties on create as the source values will not exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ContentServiceOnSaving(IContentService sender, SaveEventArgs<IContent> e)
        {
            foreach (IContent entity in e.SavedEntities)
            {
                entity.SetDefaultValue("headTitle", entity.Name);
            }
        }

        

        /// <summary>
        /// Removes hashed references to content when content is deleted.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void ContentServiceOnDeleted(IContentService sender, DeleteEventArgs<IContent> e)
        {
            ContentResolver.Instance.RemoveByIds(e.DeletedEntities.Select(x => x.Id));
        }

        /// <summary>
        /// Removes hashed references in content when content is saved.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <remarks>
        /// This is only really needed for URL based references - e.g. the URL changes
        /// </remarks>
        private static void ContentServiceOnSaved(IContentService sender, SaveEventArgs<IContent> e)
        {
            ContentResolver.Instance.RemoveByIds(e.SavedEntities.Select(x => x.Id));
        }

        /// <summary>
        /// Resets the currency formatter on Merchello settings change.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void StoreSettingServiceOnSaved(IStoreSettingService sender, SaveEventArgs<IStoreSetting> e)
        {
            StoreHelper.ResetCurrency();
        }

        /// <summary>
        /// Sets the parent of Merchello virtual product content to the Home node.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void ProductContentFactoryOnInitializing(ProductContentFactory sender, VirtualContentEventArgs e)
        {
            e.Parent = ContentResolver.Instance.GetRootContent();
        }
    }
}