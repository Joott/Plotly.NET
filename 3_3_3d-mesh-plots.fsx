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
<div id="c5460c24-851d-4223-b9a4-69890bcb8ed1" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_c5460c24851d4223b9a469890bcb8ed1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.1081258007828732,0.016904818833295636,0.3525768194126789,0.9250869755284334,0.626670452126614,0.7441460125819529,0.10424100426223176,0.08176344310946923,0.07902155540837978,0.3928759532947447,0.8180666029537407,0.691543531460475,0.502797696042246,0.1752143130522288,0.545725560535549,0.9533036248540988,0.9213678310259096,0.5980205235993585,0.05551621972374442,0.1603326299974381,0.767519730034992,0.5484682417234724,0.7226427796867876,0.37747100851380777,0.8507547405784739,0.3127904451977417,0.11979701794674481,0.1434207703654751,0.21875319966057,0.2959391350373342,0.029342058594032217,0.555859903598139,0.6933961164641176,0.6471880458515081,0.4489687240910571,0.006465530491650817,0.12724731682205914,0.8824380342301158,0.5758024196027789,0.14113398461655433,0.48540162457404734,0.5485579616150623,0.840288569145039,0.676321722416357,0.8383426749326022,0.37650213594385523,0.7761411302611889,0.15719283752012664,0.37243370589447844,0.36118331242407825],"y":[0.2530947775827231,0.10468316874684913,0.32395435186287125,0.27708910697935574,0.3225859339919807,0.5596575590594008,0.2942620391465081,0.975105810898871,0.07433223494995955,0.3138800069288723,0.624348994635208,0.9608202338967566,0.8630102434488992,0.7830824203710456,0.36353389470071246,0.26220669935560165,0.9981474149963574,0.8556096501907379,0.7262455889611718,0.5392600300438981,0.8260563080320397,0.03892979679579371,0.022218103996579582,0.9143822351071901,0.6749310054233908,0.21896176841992968,0.7081796725784334,0.046321057270430524,0.5391283335812056,0.47425260463461866,0.5366493149365528,0.9626041804266182,0.7709870644709966,0.8575698872364917,0.042844357454611154,0.924658889847183,0.23190555173526778,0.41630700948476185,0.3246021118595275,0.8893111650316562,0.7122034913451427,0.15214150592318806,0.8081057992801562,0.2619224126739066,0.5167849899813463,0.5245813906772907,0.6855477181661631,0.05720614877399344,0.3127878277156445,0.5761359755770005],"z":[0.37835472094749784,0.920531480070451,0.43094724855895494,0.8331736758505803,0.5351270043920385,0.21416498078692936,0.08246506475026955,0.40957211675568117,0.6021581015559649,0.10362416557205104,0.8514778864809674,0.24794098187607758,0.43597747731766545,0.6000796303153408,0.7772306919923195,0.6617448142085899,0.18983316942576,0.005440356212407516,0.7402380629164343,0.43887500485352937,0.030301147620333892,0.5818404055115955,0.5310075383312104,0.8369344239295154,0.8270565386987555,0.6739148021088517,0.23082399751563742,0.7602956913226729,0.39759724512584377,0.1503496147461001,0.5334140502537666,0.65097352380444,0.733533229554786,0.9629923580042051,0.09589788368712081,0.6161178348661017,0.5316569318676633,0.9378133886204163,0.32244288284445316,0.8286793766676818,0.8421938250969135,0.8223334349795866,0.8141489079287969,0.22097794628747644,0.03783327855068877,0.4642625094690651,0.7161640286055226,0.2080261689648154,0.4846917206815871,0.8550401757727564],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('c5460c24-851d-4223-b9a4-69890bcb8ed1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_c5460c24851d4223b9a469890bcb8ed1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_c5460c24851d4223b9a469890bcb8ed1();
            }
</script>
*)

