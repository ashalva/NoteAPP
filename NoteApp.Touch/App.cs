using System;
using System.ComponentModel;
using Autofac;
using NoteApp.Core.Providers;
using NoteApp.Core.Services;
using NoteApp.Core.ViewModels;

namespace NoteApp.Touch
{
	public class App
	{
		public static Autofac.IContainer Container { get; set; }

		public static void Initialize ()
		{
			var builder = new ContainerBuilder ();

			builder.RegisterType<ApiProvider> ().As<IApiProvider> ();

			builder.RegisterType<NoteService> ().As<INoteService> ();

			builder.RegisterType<NoteViewModel> ();

			App.Container = builder.Build ();
		}

	}
}

