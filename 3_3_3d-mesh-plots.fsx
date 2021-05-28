(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_3_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_3_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_3_3d-mesh-plots.ipynb)

*Summary:* This example shows how to create 3D-Mesh charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open System
open Plotly.NET 


//---------------------- Generate linearly spaced vector ----------------------
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))
    //[|min ..bw ..max|]

//---------------------- Create example data ----------------------
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> 
            f x.[j] y.[i] 
        )
    )

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())


let mesh3d =
    Trace3d.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject 
    (* output: 
<div id="edf2c086-0306-4a33-9f2c-fd28d051521c" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_edf2c08603064a339f2cfd28d051521c = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.45213561060472185,0.4926108464098586,0.39725153306371136,0.36260716494294215,0.5468961659571604,0.888548421621578,0.7960900705289515,0.19602115228586883,0.6998030635061688,0.37624154536809845,0.9487546123325613,0.225877580803762,0.7480575958024979,0.4961151357256412,0.756435334569046,0.13523252500930452,0.20781258643037295,0.9660426680771833,0.23534265590614764,0.4202555364092139,0.3965039879067354,0.06731686557983833,0.9145238133680652,0.7678181346356022,0.5711913102172275,0.5098908527334644,0.6113062727317709,0.11291504703132205,0.9149220771691399,0.09959412929583067,0.6856272195864596,0.2551622974011871,0.49572487338247007,0.21233530212768134,0.3025829602510589,0.9439171128645153,0.725013807753573,0.3712163783475833,0.8244287878388673,0.059585557812631855,0.3496646072481128,0.4644208357038073,0.12075044313480633,0.9004860310351877,0.4311320932726991,0.9391717547267544,0.9256291407745467,0.6646909861195325,0.32708241526367254,0.6154522740354074],"y":[0.7472900612034323,0.709595613046361,0.14678916109110654,0.1381615685011081,0.6493789067721828,0.38481874502488356,0.5780870330417934,0.6294333984281092,0.7914158547257147,0.037005313223696,0.27724214888980714,0.6831750234976295,0.28109907511672894,0.6002089342103382,0.6906143257816388,0.6935923149313742,0.7301527074212919,0.5357222936748165,0.19353217547458232,0.8125182217045306,0.41021871725573145,0.8365962080827897,0.14161388023831598,0.17575709809351578,0.07059092916110109,0.932083152202928,0.946566422445032,0.014037782332877526,0.3366860413629031,0.6320195554904731,0.5842617119589176,0.9466152866122384,0.7858326317676495,0.29946980313373256,0.3523040680923984,0.9760316065400986,0.1083731363100806,0.3575633048813619,0.5629563953554986,0.9177642152261754,0.3658300798227219,0.09558040932546388,0.5798005236218686,0.7874234746151713,0.7823434089228247,0.6664895837504834,0.18332176058707841,0.5205415089244682,0.20987170525354878,0.7375397783413249],"z":[0.20901904730546245,0.3899068470997302,0.4711588106449502,0.514564193559142,0.20523355677967592,0.9106938531206427,0.567981732808045,0.9710320629975908,0.06757063934000704,0.7172957545692547,0.4382523225798515,0.5640492507089159,0.2927473570652061,0.15939629923524162,0.45274360126477836,0.3306268622775687,0.89734239172998,0.9816292719829964,0.24790486611793974,0.7145827192415403,0.5852191786212936,0.37258940253993,0.9727658983193179,0.27576796024840694,0.4466881418818087,0.31463830793026754,0.25679568446092105,0.35419040562314463,0.393413689170691,0.4041013454106177,0.7487613916158496,0.4260249135205638,0.8041660770793287,0.5991462630215783,0.4230005081850106,0.19435486485918746,0.47545647596728824,0.2712684382085076,0.09423624635405664,0.44161021497175573,0.4080498737320536,0.13734107331248982,0.2899926655413549,0.8456606407862439,0.4795118926463238,0.8017808291138061,0.8028330522602578,0.42040422438662695,0.33467987335039295,0.451716546645256],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('edf2c086-0306-4a33-9f2c-fd28d051521c', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_edf2c08603064a339f2cfd28d051521c();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_edf2c08603064a339f2cfd28d051521c();
            }
</script>
*)

