﻿using Havit.Diagnostics.Contracts;
using Microsoft.AspNetCore.Components.Routing;

namespace Havit.Blazor.Components.Web.Bootstrap
{
	/// <summary>
	/// Item for the <see cref="HxSidebar"/>.
	/// </summary>
	public partial class HxSidebarItem
	{
		/// <summary>
		/// Item text.
		/// </summary>
		[Parameter] public string Text { get; set; }

		/// <summary>
		/// Item icon (optional).
		/// </summary>
		[Parameter] public IconBase Icon { get; set; }

		/// <summary>
		/// Item navigation target.
		/// </summary>
		[Parameter] public string Href { get; set; }

		/// <summary>
		/// URL matching behavior for the underlying <see cref="NavLink"/>.
		/// Default is <see cref="NavLinkMatch.Prefix"/>.
		/// </summary>
		[Parameter] public NavLinkMatch? Match { get; set; } = NavLinkMatch.Prefix;

		/// <summary>
		/// Allows you to disable the item with <c>false</c>.
		/// Default is <c>true</c>.
		/// </summary>
		[Parameter] public bool Enabled { get; set; } = true;

		/// <summary>
		/// Any additional CSS class to add.
		/// </summary>
		[Parameter] public string CssClass { get; set; }

		/// <summary>
		/// Sub-items (not intended to be used for any other purpose).
		/// </summary>
		[Parameter] public RenderFragment ChildContent { get; set; }

		[CascadingParameter] protected HxSidebar ParentSidebar { get; set; }
		[CascadingParameter] protected HxDropdown DropdownContainer { get; set; }

		[Inject] protected NavigationManager NavigationManager { get; set; }

		private string id = "hx" + Guid.NewGuid().ToString("N");

		protected override void OnParametersSet()
		{
			Contract.Requires<InvalidOperationException>(ParentSidebar is not null, $"{nameof(HxSidebarItem)} has to be placed inside {nameof(HxSidebar)}.");
		}

		protected bool HasExpandableContent => (this.ChildContent is not null);
	}
}
