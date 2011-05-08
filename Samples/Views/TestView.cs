using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Samples
{
	using System;
	using MonoMobile.MVVM;
	
	[Theme(typeof(BackgroundImageTheme))]
	[Theme(typeof(NavbarTheme))]
	[Theme(typeof(FrostedTheme))]
	public class TestView : View
	{
	[Section("Enumerables")]
		public TestEnum TestEnum;
		[PopOnSelection]
		public TestEnum PopEnum;
		public EnumCollection<TestEnum> EnumCollection = new EnumCollection<TestEnum>();
		public IEnumerable MyList = new List<string>() { "Windows", "OS X", "Linux"};
		public MultiselectCollection<string> MySelectableList = new MultiselectCollection<string>() { "Windows", "OS X", "Linux" }; 

		[Root(ViewType = typeof(MovieView))]
		public ObservableCollection<MovieViewModel> Movies;

		public List<MyObject> Tests = new List<MyObject>() { new MyObject(), new MyObject() };

	[Section("Fields")]
		[Entry]
		public string String = "a string";
		public bool Bool = true;
		public int Int = 5;
		[Range(1, 30, ShowCaption = false)]
		public float Float = 8.3f;
		public DateTime DateTime1;
		public UIImage Image;
		public Uri Uri;
		[Map("A Map")]
		public CLLocationCoordinate2D Location;


	[Section("Properties")]
		public string StringProperty { get; set; }
		public bool BoolProperty { get; set; }
		public int IntProperty { get; set; }
		public float FloatProperty { get; set; }
		public DateTime DateTime1Property { get; set; }
		public UIImage ImageProperty { get; set; }
		public Uri UriProperty { get; set; }
		[Map("A Map")]
		public CLLocationCoordinate2D LocationProperty { get; set; }

	[Section("Classes")]
		public MyObject MyObject { get; set; }
		
		//[Inline]
		public ButtonTestView ButtonTestView { get; set; }

		public TestView()
		{
			ButtonTestView = new ButtonTestView();

			Uri = new Uri("Http://www.google.com");
			DateTime1 = DateTime.Now;
			Image = UIImage.FromFile("Images/brick.jpg");
			Location = new CLLocationCoordinate2D(-33.867139, 151.207114);

			StringProperty = String;
			BoolProperty = Bool;
			IntProperty = Int;
			FloatProperty = Float;
			DateTime1Property = DateTime1;
			ImageProperty = Image;
			UriProperty = Uri;
			LocationProperty = Location;

			MyObject = new MyObject();

			Movies = new ObservableCollection<MovieViewModel>();
			var dataModel = new MovieDataModel();
			dataModel.Load();
			Movies =dataModel.Movies;
		}
	}

	public class MyObject :View
	{
		public string TestString = "A Test String"; 

	[Section("Lists")]
		public TestEnum TestEnum;
		[PopOnSelection]
		public TestEnum PopEnum;
		public EnumCollection<TestEnum> EnumCollection = new EnumCollection<TestEnum>();
		public IEnumerable MyList = new List<string>() { "Windows", "OS X", "Linux"};
		public MultiselectCollection<string> MySelectableList = new MultiselectCollection<string>() { "Windows", "OS X", "Linux" }; 

		[Root(ViewType = typeof(MovieView))]
		public ObservableCollection<MovieViewModel> Movies;

		public MyObject()
		{
			Movies = new ObservableCollection<MovieViewModel>();
			var dataModel = new MovieDataModel();
			dataModel.Load();
			Movies =dataModel.Movies;
		}
	}

	public enum TestEnum
	{
		One, 
		Two,
		Three,
		Apple, 
		Orange,
		[Description("Slippers & Socks")]
		SlippersAndSocks
	}
}

