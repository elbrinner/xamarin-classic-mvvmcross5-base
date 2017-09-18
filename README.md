
<div class="post-body"><div class="date-header"><span itemprop="author" class="byline-author" itemscope="" itemtype="http://schema.org/Person"> </div><p itemprop="articleBody"></p><p>Cuando se empieza a desarrollar con Xamarin y buscamos tutoriales por internet vemos una seria patrones de diseño, buenas prácticas y siglas que dar algo de respecto cuando no lo conocemos, como puede ser MVVM, inyección de dependencias, contenedores IOC, converters, command, binding, custom presenter y etc…</p>

<p>La parte buena es que de forma inicial existen frameworks como MvvmCross que ofrece toda la arquitectura inicial para empezar sin tener que conocer cada pieza al detalle desde el principio.</p>

<p>Para crear nuestro proyecto “Base” con MvvmCross desde 0, hay que seguir los siguientes pasos.</p>

<p><strong>Paso 1</strong>, crear una solución vacía. Está solución será el contenedor principal de todos nuestros proyectos que vamos agregar.</p>

<p><img alt="Nueva solución" src="/img/1_base.PNG"></p>

<p><strong>Paso 2</strong>, agregar un proyecto para la lógica de negocio, un proyecto de tipo PCL. Para agregar tenemos que hacer clic con el segundo botón sobre el nombre de la solución vacía, al hacer clic con el segundo botón se abre un menú de opciones y debemos elegir agregar y luego nuevo proyecto.</p>

<p>&nbsp;</p>

<p>Ahora tenemos que seleccionar el tipo de proyecto que queremos, en nuestro caso un proyecto de tipo C# que sea una librería de clase portable, lo vamos a llamar de Base.Core. Base porque es el nombre de nuestra solución y Core porque se trata del proyecto que va a contener la lógica de negocio, nomenclatura usada de forma extendida dentro de las comunidades de desarrolladores.</p>

<p><img alt="Seleccionar una PCL" src="/img/2_pcl.PNG"></p>

<p><strong>Paso 3</strong>, elegir el perfilado de la PCL, seleccionamos los tipos de proyectos que queremos compartir la lógica de negocio, en nuestro caso necesitamos para IOS, Android y UWP.</p>

<p><img alt="" src="/img/3_profile.PNG"></p>

<p>&nbsp;</p>

<p>Haga clic en aceptar y se creará el proyecto. Elimine el archivo Class1.cs que no vamos a necesitar.</p>

<p>&nbsp;</p>

<p><strong>Paso 4</strong>: Crear todos los proyectos de plataforma, Android, UWP y IOS. El proceso es similar al anterior, pero en lugar de crear un proyector de tipo PCL, vamos a crear un de tipo plataforma.</p>

<p><strong>Para Android</strong></p>

<p><strong><img alt="" src="/img/4_droid.PNG"></strong></p>

<p><strong>Para IOS</strong></p>

<p><strong><img alt="" src="/img/5_IOS.PNG"></strong></p>

<p><strong>Para UWP - Windows</strong></p>

<p><strong><img alt="" src="/img/6_uwp.PNG"></strong></p>

<p>Seleccionamos la versión de destino de la aplicación y la versión mínima que suportará la aplicación.</p>

<p><img alt="" src="/img/6_1_uwp.PNG"></p>

<p><strong>Paso 5, l</strong>a principal ventaja de Xamarin es la reutilización, como toda nuestra lógica de negocio está en el proyecto Base.Core, lo vamos referéncialo en todos los proyectos de plataforma. Para referenciar haga clique con el segundo botón sobre referencias y seleccione la opción <strong>agregar referencia</strong> del menú. Haga clic sobre solución y elijar el proyecto de tipo PCL (Base.Core) y haga clic en aceptar.</p>

<p><img alt="" src="/img/7_compartir_pcl.PNG">El resultado es la librería <strong>Base.Core</strong> dentro de las referencias.</p>

<p><img alt="" src="/img/7_2.PNG"></p>

<p>&nbsp;</p>

<p><strong>Paso 6,</strong>&nbsp;Agregar la librería de MvvmCross desde nuget, existe una versión que agiliza la configuración del proyecto. Haga clic con el segundo botón sobre la solución Base y seleccione la opción <strong>administrar paquetes nuget </strong>para la solución y busque por <strong>mvvmcross starter</strong>.</p>

<p>&nbsp;</p>

<p><img alt="" src="/img/8_mvvmcross.PNG"></p>

<p>&nbsp;</p>

<p>Seleccione todos los proyectos y haga clic en instalar. Se va abrir una ventana que indica todo que se va instalar en cada uno de los proyectos, haga clique en aceptar para empezar la instalación, este proceso puede tardar unos segundos.</p>

<p><img alt="" src="/img/8_1.PNG"></p>

<p>&nbsp;</p>

<p><strong>Paso 7,</strong>&nbsp;Comprobar la configuración del proyecto de <strong>Base.Core</strong>.</p>

<p>Podemos comprobar que al instalar el paquete de nuget de MvvmCross se agregó algunos archivos en el proyecto.</p>

<p>Un archivo MainViewModel.cs con la lógica de negocio “hola mundo” que contiene una propiedad pública que se usará en la vista de la plataforma y un ICommand que llamar a una función que volver a reiniciar el valor de la propiedad pública.</p>

<p><img alt="" src="/img/9_1_archivos_creado_en_core.PNG"></p>

<p>&nbsp;</p>

<p>La clase App.cs proporciona la inicialización para su lógica de negocio principal y sus modelos de vista.</p>

<p>La línea que esta destacada en el código, será la vista principal a cargar, en este caso cargará la vista MainView, esta vista está asociado al viewmodel MainViewModel.</p>

<p><img alt="" src="/img/9_2_archivos_creado_en_core_app.PNG"></p>

<p>&nbsp;</p>

<p>Para configurar la base del proyecto “hola mundo” no tenemos que hacer nada más en este proyecto.</p>

<p><strong>Paso 8,</strong>&nbsp;Configurar proyecto Android. MvvmCross facilita la configuración, tenemos que hacer 2 cosas, agregar la referencia del proyecto Core que ya hicimos en los pasos anteriores y eliminar el archivo MainActivity.cs , en su lugar mvvmcross va a trabajar con las vistas que hereda de MvxActivity.</p>

<p><img alt="" src="/img/10_1_configurar_android.PNG"></p>

<p>Una vez eliminado el archivo MainActivity.cs ejecutamos la solución en el simulador de Android o en un terminal. En mi caso voy a ejecutar en un Samsung SM, solo tenemos que hacer clic sobre el botón.</p>

<p>Ha ocurrido un error en la compilación, hay un recurso que no se está encontrando.</p>

<p><img alt="" src="/img/10_2_error.PNG"></p>

<p>Abra el fichero SplashScreen.cs y modifique la siguiente línea:</p>

<pre><code class="language-cs hljs">, Icon = <span class="hljs-string">"@mipmap/icon"</span></code></pre>

<p>Por esta:</p>

<pre><code class="language-cs hljs">, Icon = <span class="hljs-string">"@drawable/icon"</span></code></pre>

<p><img alt="" src="/img/10_3.PNG"></p>

<p>Vuelva a compilar la aplicación. Ahora todo debería funcionar de forma correcta, debería ver una pantalla negra con un texto “Hello MvvmCross” con un botón de reset.</p>

<p>Antes de empezar a crear su aplicación, elimine la carpeta ToDo-MvvmCross.</p>

<p>&nbsp;</p>

<p><strong>Paso 9,</strong> configurar proyecto IOS. Tenemos que hacer la referencia del proyecto de Core que ya hicimos en los pasos anteriores y modificar el archivo AppDelegate.cs , los nuevos valores a aplicar están en el archivo AppDelegate.cs.txt</p>

<p><img alt="" src="/img/11_ios_mvvmcross.PNG">AppDelegate ahora debe hereda de MvxApplicationDelegate.</p>

<p>Debemos cambiar:</p>

<pre><code class="language-cs hljs"><span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">AppDelegate</span> : <span class="hljs-title">UIApplicationDelegate</span></code></pre>

<p>Por:</p>

<pre><code class="language-cs hljs">&nbsp;<span class="hljs-keyword">public</span> <span class="hljs-keyword">partial</span> <span class="hljs-keyword">class</span> <span class="hljs-title">AppDelegate</span> : <span class="hljs-title">MvxApplicationDelegate</span></code></pre>

<p>También es necesario modificar la función FinishedLaunching.</p>

<p>Debemos cambiar:</p>

<pre><code class="language-cs hljs"><span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">bool</span> <span class="hljs-title">FinishedLaunching</span> (<span class="hljs-params">UIApplication application, NSDictionary launchOptions</span>)
</span>{
&nbsp; &nbsp; &nbsp;<span class="hljs-comment">// Override point for customization after application launch.</span>
	<span class="hljs-comment">// If not required for your application you can safely delete this method</span>

<span class="hljs-keyword">return</span> <span class="hljs-literal">true</span>;
}
</code></pre>

<p>Por</p>

<pre><code class="language-cs hljs"><span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">bool</span> <span class="hljs-title">FinishedLaunching</span>(<span class="hljs-params">UIApplication application, NSDictionary launchOptions</span>)
</span>{
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Window = <span class="hljs-keyword">new</span> UIWindow(UIScreen.MainScreen.Bounds);

&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="hljs-keyword">var</span> setup = <span class="hljs-keyword">new</span> Setup(<span class="hljs-keyword">this</span>, Window);
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; setup.Initialize();

&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="hljs-keyword">var</span> startup = Mvx.Resolve();
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; startup.Start();

&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Window.MakeKeyAndVisible();

&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="hljs-keyword">return</span> <span class="hljs-literal">true</span>;
}
</code></pre>

<p>&nbsp;</p>

<p>El último paso es agregar las referencias de MvvmCross.</p>

<pre><code class="language-cs hljs"><span class="hljs-keyword">using</span> MvvmCross.Core.ViewModels;
<span class="hljs-keyword">using</span> MvvmCross.iOS.Platform;
<span class="hljs-keyword">using</span> MvvmCross.Platform;
</code></pre>

<p>Ya estamos listo para probar, recuerde que vamos a necesitar de un Mac para compilar.</p>

<p>&nbsp;</p>

<p>En la versión que estoy probando, se ha producido un error en el fichero Setup.cs</p>

<p><img alt="" src="/img/11_error_ios.PNG"></p>

<p>Abrimos el fichero <strong>Setup.cs</strong> y aplicamos los siguientes cambios.</p>

<p>Cambiar:</p>

<pre><code class="language-cs hljs">&nbsp;<span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">Setup</span>(<span class="hljs-params">IMvxApplicationDelegate applicationDelegate, UIWindow window, IMvxIosViewPresenter presenter</span>)
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <span class="hljs-title">base</span>(<span class="hljs-params">applicationDelegate, window, presenter</span>)
&nbsp; &nbsp; &nbsp; &nbsp; </span>{
&nbsp; &nbsp; &nbsp; &nbsp; }

</code></pre>

<p>Por:</p>

<pre><code class="language-cs hljs">
&nbsp;<span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">Setup</span>(<span class="hljs-params">IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter</span>)
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <span class="hljs-title">base</span>(<span class="hljs-params">applicationDelegate, presenter</span>)
&nbsp; &nbsp; &nbsp; &nbsp; </span>{
&nbsp; &nbsp; &nbsp; &nbsp; }
</code></pre>

<p>&nbsp;</p>

<p>Ahora debería funcionar, elimine la carpeta ToDo-MvvmCross y ya puedes empezar tu aplicación para IOS.</p>

<p>&nbsp;</p>

<p><strong>Paso 10,&nbsp;</strong>&nbsp;configurar proyecto para UWP. Para la configuración para UWP mvvmCross no genera ningún tipo de archivo, así que tenemos que hacer todo el trabajo de forma manual.</p>

<p>Lo primero que tenemos que hacer es agregar la referencia del proyecto de Core, que ya hicimos en los pasos anteriores.</p>

<p>Tenemos que crear una carpeta para las vistas, hacemos clique con el segundo botón sobre el proyecto de Base.UWP y elegimos la opción agregar y luego, la opción nueva carpeta, llamaremos la nueva carpeta de Views.</p>

<p>Ahora hacemos clique sobre la carpeta Views con el segundo botón, elegimos la opción de agregar y luego la opción de nuevo elemento. Se va abrir una ventana que se ver en la imagen abajo, debemos crear una página en blanco con el nombre de MainView.</p>

<p><img alt="" src="/img/12_1_uwp.PNG"></p>

<p>Antes de empezar a trabajar con la vista nueva, vamos a eliminar el archivo <strong>MainPage.xaml </strong>del proyecto que no lo necesitamos al usar MvvmCross.</p>

<p>Abrimos el archivo MainView.xaml.cs y quitamos la herencia de Page y agregamos la de MvxWindowsPage, el resultado será el siguiente.</p>

<pre><code class="language-cs hljs"><span class="hljs-keyword">using</span> Windows.UI.Xaml.Navigation;

<span class="hljs-comment">// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238</span>

<span class="hljs-keyword">namespace</span> <span class="hljs-title">Base.UWP.Views</span>
{
    <span class="hljs-comment"><span class="hljs-doctag">///</span> </span></code></pre>

<p><code class="language-cs">/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame. /// </code></p>

<p><code class="language-cs">public sealed partial class MainView : MvxWindowsPage { public MainView() { this.InitializeComponent(); } } } </code></p>

<p>Tenemos que hacer lo mismo con el código Xaml, cambiar page por views:MvxWindowsPage y agregar la referencia.</p>

<p>&nbsp;</p>

<pre><code class="language-cs hljs">xmlns:views=<span class="hljs-string">"using:MvvmCross.Uwp.Views"</span>
</code></pre>

<p>&nbsp;</p>

<p>El resultado será este:</p>

<p>&nbsp;</p>

<p><img alt="" src="/img/13_4.PNG"></p>

<p>&nbsp;</p>

<p>Vamos a crear el archivo <strong>Setup.cs</strong> en la raíz del proyecto de Base.UWP, hacemos clique sobre la solución, elegimos la opción agregar y luego la opción nuevo elemento. Se va abrir una ventana que podemos elegir el tipo de archivo y el nombre, seleccionamos de tipo clase y con el nombre Setup.cs</p>

<p>&nbsp;</p>

<p><img alt="" src="/img/13_5.PNG"></p>

<p>&nbsp;</p>

<p>El código que va a contener este archivo es el siguiente:</p>

<p>&nbsp;</p>

<pre><code class="language-cs hljs"><span class="hljs-keyword">using</span> MvvmCross.Core.ViewModels;
<span class="hljs-keyword">using</span> MvvmCross.Platform.Plugins;
<span class="hljs-keyword">using</span> MvvmCross.Uwp.Platform;
<span class="hljs-keyword">using</span> Windows.UI.Xaml.Controls;

<span class="hljs-keyword">namespace</span> <span class="hljs-title">Base.UWP</span>
{
    <span class="hljs-keyword">public</span> <span class="hljs-keyword">class</span> <span class="hljs-title">Setup</span> : <span class="hljs-title">MvxWindowsSetup</span>
    {
        <span class="hljs-function"><span class="hljs-keyword">public</span> <span class="hljs-title">Setup</span>(<span class="hljs-params">Frame rootFrame</span>) : <span class="hljs-title">base</span>(<span class="hljs-params">rootFrame</span>)
        </span>{
        }

        <span class="hljs-function"><span class="hljs-keyword">protected</span> <span class="hljs-keyword">override</span> IMvxApplication <span class="hljs-title">CreateApp</span>(<span class="hljs-params"></span>)
        </span>{
            <span class="hljs-keyword">return</span> <span class="hljs-keyword">new</span> Core.App();
        }

        <span class="hljs-function"><span class="hljs-keyword">protected</span> <span class="hljs-keyword">override</span> IMvxPluginManager <span class="hljs-title">CreatePluginManager</span>(<span class="hljs-params"></span>)
        </span>{
            <span class="hljs-keyword">return</span> <span class="hljs-keyword">base</span>.CreatePluginManager();
        }

        <span class="hljs-function"><span class="hljs-keyword">protected</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">void</span> <span class="hljs-title">InitializeFirstChance</span>(<span class="hljs-params"></span>)
        </span>{

        }
    }
}

</code></pre>

<p>&nbsp;</p>

<p>El siguiente paso es abrir el archivo App.Xaml.cs y remplazar la función OnLaunched por esta:</p>

<pre><code class="language-cs hljs"><span class="hljs-function"><span class="hljs-keyword">protected</span> <span class="hljs-keyword">override</span> <span class="hljs-keyword">void</span> <span class="hljs-title">OnLaunched</span>(<span class="hljs-params">LaunchActivatedEventArgs e</span>)
        </span>{
            Frame rootFrame = Window.Current.Content <span class="hljs-keyword">as</span> Frame;

            <span class="hljs-comment">// No repetir la inicialización de la aplicación si la ventana tiene contenido todavía,</span>
            <span class="hljs-comment">// solo asegurarse de que la ventana está activa.</span>
            <span class="hljs-keyword">if</span> (rootFrame == <span class="hljs-literal">null</span>)
            {
                <span class="hljs-comment">// Crear un marco para que actúe como contexto de navegación y navegar a la primera página.</span>
                rootFrame = <span class="hljs-keyword">new</span> Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                <span class="hljs-keyword">if</span> (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    <span class="hljs-comment">//<span class="hljs-doctag">TODO:</span> Cargar el estado de la aplicación suspendida previamente</span>
                }

                <span class="hljs-comment">// Poner el marco en la ventana actual.</span>
                Window.Current.Content = rootFrame;
            }



            <span class="hljs-keyword">if</span> (rootFrame.Content == <span class="hljs-literal">null</span>)
            {
                <span class="hljs-comment">// Cuando no se restaura la pila de navegación, navegar a la primera página,</span>
                <span class="hljs-comment">// configurando la nueva página pasándole la información requerida como</span>
                <span class="hljs-comment">//parámetro de navegación</span>
                <span class="hljs-comment">//rootFrame.Navigate(typeof(MainPage), e.Arguments);</span>
                <span class="hljs-keyword">var</span> setup = <span class="hljs-keyword">new</span> Setup(rootFrame);
                setup.Initialize();

                <span class="hljs-keyword">var</span> start = Mvx.Resolve<imvxappstart>();
                start.Start();
            }
            <span class="hljs-comment">// Asegurarse de que la ventana actual está activa.</span>
            Window.Current.Activate();
        }</imvxappstart></code></pre>

<p>&nbsp;</p>

<p>Debemos agregar las referencias que faltan que son:</p>

<pre><code class="language-cs hljs"><span class="hljs-keyword">using</span> MvvmCross.Core.ViewModels;
<span class="hljs-keyword">using</span> MvvmCross.Platform;
</code></pre>

<p>&nbsp;</p>

<p>Establecemos el Proyecto de Base.UWP como proyecto de inicio y le damos la opción de implementar la solución, con esto debemos ver una pantalla en blanco y la configuración base ya está completada. Para iguala la pantalla vamos a modificar nuestra vista para agregar 2 campos para que se muestre lo mismo que en los proyectos de IOS y Android.</p>

<p><img alt="" src="/img/13_6.PNG"></p>

<p>&nbsp;</p>

<p>&nbsp;</p>
<p></p></div>
