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
<div id="a027d54d-e4f5-489e-9d01-84fcc4dd480f" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_a027d54de4f5489e9d0184fcc4dd480f = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.6517106320949787,0.5573999358142726,0.6435793170908369,0.20366579536519283,0.7706389332984755,0.4223729471780234,0.8065980918736189,0.7569015206568416,0.26389596856380626,0.2281194949653556,0.3772837041771429,0.9830091860997533,0.7439419742412595,0.37603738548980903,0.8046942804030581,0.47206200634691026,0.743382659155588,0.3937271942355331,0.7028625620076724,0.7994099305008584,0.845189043248626,0.3666169784807679,0.17887688250228617,0.7047282274368816,0.8831448261081916,0.48217034595188235,0.6294751854750678,0.9202018486895607,0.4298758280602637,0.597700239903154,0.31449051588517174,0.15411373886936983,0.7574603360879516,0.7088038477621991,0.3743868495218395,0.34170775876460024,0.8559524122886139,0.5295667427263999,0.733102435121826,0.3070736738420435,0.8752567609191205,0.6566631396564949,0.6416996911362278,0.8620979785277033,0.1865534606327086,0.17479656598288407,0.5633832330644984,0.9813708895730651,0.3580091480901507,0.3782638778808824],"y":[0.9784141476165569,0.5952069184720549,0.9438687795511768,0.6617624669623386,0.6846268007925836,0.28509365361421074,0.37852305331198643,0.9388510896539554,0.3205209692570013,0.2884685873465932,0.7928977617029556,0.8863962431840581,0.3270256925965779,0.6661957286606522,0.9136289790801839,0.22316996530777308,0.22554885001180175,0.03513812647906045,0.0016505359679695852,0.4629865216384579,0.6161095940582965,0.21381591642918807,0.660624759113707,0.39578888816562896,0.9241531695817379,0.18852590359213106,0.7249172873445401,0.31677890397458286,0.518174766804173,0.7083482601253075,0.9187871128873839,0.6481042959020027,0.56219270059941,0.05161195017938127,0.619286092286597,0.7192835974131169,0.21024495931819312,0.09569786912561296,0.02417704696961541,0.08929319590762871,0.9631847054526138,0.9171013226346585,0.20904577346939862,0.4446338477752329,0.5141759121390879,0.9888605177350624,0.329637447059917,0.9755039624755755,0.9484689994475194,0.9633834953249355],"z":[0.9492477159710823,0.528245106585438,0.9797203536050955,0.8950226264516928,0.762154283822586,0.7645982311873688,0.9345821593583479,0.5480798913855478,0.7376092973806008,0.4961008972004526,0.5601763662696706,0.06174414933740355,0.42067632284978235,0.6121727091316937,0.36968147445920924,0.14479346580095284,0.3242035425846481,0.2754137424171966,0.046909636374055236,0.194345381667067,0.012925005989579953,0.1298509808861888,0.010961079509445037,0.9123573400603409,0.49980181618584407,0.699008271423638,0.0047701429597894396,0.2159909113384741,0.8816129760265411,0.9352926518466755,0.858888456532214,0.7494133248689646,0.3683099045270634,0.5547912714792375,0.7591005441542251,0.390542006301946,0.6683839422969072,0.6671700741477171,0.2894576663567953,0.8546878610992282,0.784701438054769,0.6621650679326454,0.35808857174501224,0.5280761497691628,0.5291168296379581,0.9014405561152103,0.49642499978487614,0.5968730643377048,0.07495237331602367,0.36938244633813505],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('a027d54d-e4f5-489e-9d01-84fcc4dd480f', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_a027d54de4f5489e9d0184fcc4dd480f();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_a027d54de4f5489e9d0184fcc4dd480f();
            }
</script>
*)

