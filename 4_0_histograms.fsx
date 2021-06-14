(**
// can't yet format YamlFrontmatter (["title: Histograms"; "category: Distribution Charts"; "categoryindex: 5"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Histograms

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_0_histograms.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/4_0_histograms.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/4_0_histograms.ipynb)

*Summary:* This example shows how to create a one-dimensional histogram of a data samples in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 

let rnd = System.Random()
let x = [for i=0 to 500 do yield rnd.NextDouble() ]
(**
A histogram consisting of rectangles whose area is proportional to the frequency of a variable and whose width is equal to the class interval.
The histogram chart represents the distribution of numerical data and can be created using the `Chart.Histogram` function:.

*)
let histo1 =
    x
    |> Chart.Histogram
    |> Chart.withSize(500.,500.)(* output: 
<div id="22b1b3e5-1a0f-41b3-bf58-7daa7c4938b1" style="width: 500px; height: 500px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_22b1b3e51a0f41b3bf587daa7c4938b1 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"histogram","x":[0.4655755299448853,0.8303334307066786,0.8789096571872521,0.18174319722770862,0.7261038342146686,0.826072369621169,0.6668008550381291,0.22142659603684517,0.09669762016120256,0.09733232534366303,0.2866469287717002,0.967826501451352,0.07760631017275449,0.20678993370700158,0.07383797414313907,0.5730956516103333,0.15262751660897747,0.016458707869266488,0.681631988697514,0.09195694843863926,0.505964459621331,0.8597744437212936,0.895807083181947,0.9827586873354198,0.22327876241099032,0.7007300987377437,0.7226390371670197,0.21325893011561545,0.5944505248192933,0.11639839369635954,0.0531673212783259,0.5833204335455412,0.3079827098678717,0.2660159060107618,0.049335488141204926,0.17085770758374488,0.7357838152608759,0.6233899484497448,0.36503084207187914,0.6415665390163504,0.1048307396028334,0.8650917698932308,0.5213040027400963,0.5084118822163026,0.9752731067013336,0.8403607173079441,0.9115338241269504,0.35486222354455954,0.694447726800315,0.8748358236042949,0.2639067965857251,0.06819386830003647,0.8405176381769206,0.45400832148921133,0.8965453910159624,0.6058010862235916,0.9345263475247316,0.8961509698518324,0.9584644348167183,0.025373735476924914,0.1034333324541493,0.4535419249225137,0.6269760712175518,0.980299226464843,0.044165004065337125,0.703326495226159,0.6598437915834802,0.8115904041619927,0.15745444556579666,0.9029802665593942,0.8373118363494574,0.5292375681592326,0.6514278657973874,0.04006544968116351,0.9871262088358058,0.6408726897281002,0.3384704409811974,0.3873952009656444,0.007485580634086197,0.3829180451030461,0.7891962746107933,0.3677768136224602,0.5188112033153005,0.7196147012149984,0.8524915971106345,0.9849734529782894,0.7428027953686206,0.8539743883786604,0.3694705149947994,0.4435344019176133,0.23633136005901328,0.8396328454090435,0.6649255136330265,0.3396571065949542,0.5381332065622011,0.6512888146803196,0.23811569867567892,0.5410047762752532,0.4642468781509655,0.2719466114751746,0.18051692572446396,0.09994341996495772,0.19740777797876288,0.7914674602409207,0.03752398725483752,0.7346692284264924,0.4167660025026491,0.8004521884957572,0.46688211265340546,0.25567270128786224,0.26733064524239425,0.5471311465590871,0.8886653892177462,0.5755463897136722,0.23617746086613156,0.7356565188316891,0.9347307216072133,0.9073613700025535,0.12780762935420853,0.0591915510870477,0.9605236998575384,0.8058694032048198,0.44211988916719325,0.7139200436481834,0.6666489065003809,0.9976789909404139,0.8643120545262062,0.3117707592024332,0.5019322431189623,0.3358373941554862,0.4027569910524213,0.797465664705944,0.923148322814679,0.7355389691589116,0.20240111937858216,0.6892528546458356,0.17036903564369726,0.7273437430743798,0.6820907139601609,0.11782236868414207,0.5682074504756404,0.9423506068728634,0.3870922757252549,0.11379781370693716,0.17620375667521904,0.6892002134999261,0.9509674561912974,0.08937912391935435,0.10347964572882264,0.802476687730512,0.7165580930731064,0.3307543286731254,0.41319714692104476,0.4050553270639178,0.3114229116176362,0.3746475225196441,0.6578235307977645,0.4834877343305795,0.12481855374053985,0.03984499631442362,0.8703571739002863,0.10499524330021592,0.29851994537679477,0.13104471849791927,0.852915710235441,0.46986498053645015,0.6239828237444083,0.15312642005883456,0.37314527033509,0.5469246062202959,0.5652874831879919,0.2073869785328335,0.22527065604239266,0.009985260670066467,0.49098410061140735,0.018173092984675007,0.4187771274795649,0.3283220754602561,0.5377162869729644,0.9774486930004548,0.04671153474911653,0.7749329306068518,0.20829111347361054,0.6994555553884504,0.6192793010823798,0.07200266237929587,0.38426851778489934,0.5180929957507612,0.4241160575412754,0.827753596858938,0.03142932384807119,0.6868813013131178,0.6025251893338399,0.6422457176457372,0.24746519478385579,0.46321220717542444,0.6438306614960687,0.2560475572273357,0.2608821034714962,0.7063387761387689,0.06521738975551788,0.7978410361324628,0.7162338535842644,0.5565550395085267,0.2371892045425201,0.5091711145402729,0.10548367263073273,0.40321188625097826,0.9140712264525105,0.2932498186329612,0.9558703950400792,0.32950145533750835,0.9457714473576152,0.14736986074008507,0.9931334615653071,0.09542424329343449,0.8967041298266054,0.5990643899883443,0.5117654174155395,0.7809130478561451,0.08559646275155082,0.10588982799364711,0.7290103625175591,0.5453916734761519,0.5154952823722248,0.8784061818748742,0.6048617891989936,0.5830249383966555,0.7625200658862107,0.027771893435982936,0.37434243148860635,0.16272957025222926,0.06743997198875992,0.8313775108341954,0.9122313032449368,0.24887049861665372,0.05869907702258745,0.6517360739650838,0.4622663508459303,0.11010818654210688,0.9665189897485631,0.9810566315339211,0.6040217692982507,0.13086623890831425,0.8718832018188588,0.7019278685105629,0.7411098539555026,0.45515532859375485,0.6491122560804301,0.1520409514904213,0.566508077348819,0.04476627150772432,0.7442821398117963,0.4799690556153511,0.6207423133872181,0.9593275617618707,0.06883067361490366,0.17084218010811236,0.04105975713630196,0.35878302266764595,0.9043093253412793,0.5224587342340773,0.6406918203647676,0.8862993330165275,0.9189073871443548,0.79314082478785,0.2620614833487484,0.11439393652341978,0.23513855749514817,0.7442629629486534,0.03672516627084704,0.24496805586152154,0.136798039142414,0.4016572308734326,0.8143940581075819,0.10453983121762976,0.5018680586953964,0.5981441236092448,0.6735084716572931,0.8135674138616619,0.13729632791937157,0.1497064606052388,0.9339126823162254,0.6104791143957894,0.4612638160871639,0.329576159980882,0.41844743044043303,0.5874709163734089,0.21063519744697734,0.9529037414830661,0.18003982500175006,0.8878568969144751,0.6106763168287819,0.10348332817828437,0.20579886120082758,0.44406025551448586,0.34036481116915346,0.7177224362817232,0.21195885176395943,0.07874237703100889,0.4398663851618145,0.6267159174320828,0.22001677109860665,0.9048492931317768,0.11531578521957425,0.3215400214872975,0.9079682323653103,0.3426249089383636,0.6655749975077692,0.5162024821695883,0.4574595030664743,0.4706865500056588,0.49733370845081926,0.22749234327464007,0.22148669474827437,0.7546028647360405,0.5885460519178519,0.030212705968978213,0.4250355169293636,0.5893312271634727,0.3746933943474169,0.6745905669753396,0.9037587390764424,0.28223481601208206,0.5642231379469033,0.14886826935637196,0.6342917390327396,0.033314710964129635,0.195858369672605,0.37033380259309606,0.7641750200484763,0.7841456224136732,0.38618527184528545,0.5947660946262843,0.3737010286998474,0.5105804104872887,0.9296896895066321,0.029063389184448583,0.49516332917621514,0.1397237945998664,0.42160792761557175,0.07582252150206945,0.9218959188656397,0.694432715277389,0.4954442384165918,0.7093532749960912,0.39052318846365586,0.3831839735541418,0.88199663343001,0.45119599646478703,0.855514203596634,0.3101521052001752,0.2926869193523596,0.6226276246004867,0.704048982683592,0.7652758181864748,0.7229571783556403,0.9377819550865246,0.34062615518487344,0.9664475158632023,0.6872482824545578,0.8746535214011807,0.1467665392657586,0.2952411949146731,0.752027462121112,0.6733138806528011,0.08450127816037334,0.902567613824535,0.8537913145747926,0.7109062842609856,0.8249131752294084,0.5594826627334033,0.5350493767927631,0.2853117223294972,0.16772329954790105,0.29887087284534747,0.7526946481096999,0.2093260237990534,0.7867905775954903,0.854869862950812,0.7583450808927161,0.25110776547859787,0.15131807753411963,0.7446623732078179,0.5148195989964621,0.45402291484830104,0.4914587030613137,0.7635576472447988,0.8907171119426922,0.6084252105133725,0.7876232321316484,0.9919077344201076,0.6884372339995751,0.5287158133130129,0.45247551214530857,0.5469544062143911,0.9290559822363108,0.6266547239509666,0.942405253156277,0.8221303577637907,0.6248519968357179,0.48795557463912087,0.5293926589793492,0.17109034916902444,0.6262828212353787,0.29603154086323064,0.7751027284074121,0.007375197022862359,0.4549043250525856,0.40517810983824454,0.012581170076774978,0.5136311545565869,0.15099137749103428,0.4857562922340614,0.2081024349704862,0.43614051697596,0.7233354438670611,0.40210416605794064,0.7804215959182109,0.29800454727281095,0.1818551775914874,0.32094363091557454,0.011850501881842735,0.24536610406142012,0.9232830521293371,0.8330054408093008,0.8710454287338282,0.006333563479750214,0.8328362101841886,0.6207688933335099,0.3698148906090366,0.1260399241587333,0.2669207706427764,0.9646602198316996,0.2300178661150941,0.27038950625359526,0.7217151064992487,0.9802277283650952,0.11837955197243931,0.21878805813323152,0.6789201864408889,0.48408350603845135,0.3086533221922132,0.48553900210444767,0.5958440404365976,0.2739920775750615,0.8409163569290733,0.2026809417655137,0.3206133783425267,0.016334995169348547,0.82361896234733,0.5269518161783702,0.8462331280327556,0.644400705883466,0.6402751801723033,0.30390836592014336,0.47610507275727815,0.284026554917929,0.24780729703968732,0.7932773804260778,0.4249861121294024,0.768769164927662,0.1745389868386737,0.8341354317190757,0.03536321922920794,0.8865412459180416,0.24671038391381053,0.18633115765933467,0.2557384261189673,0.9377129287168909,0.7144254104767113,0.7431077155019659,0.28372461408550137,0.5616335377849795,0.6190843608319221,0.6977716715530361,0.012290308723361376,0.526311499777395,0.6495220636248226,0.6492909745542756,0.9920890838802275,0.6683644869683145,0.6857201851372235,0.8165012150148401,0.7971499309861799,0.8428630744306664,0.2798067961259777,0.6225200647593103,0.3243850396593963,0.9261095001949508,0.794284433496317,0.4376885515813197,0.7324204313254079,0.3251021715463615,0.7938019460038291,0.9101510215132269,0.30954451919977766,0.4745178904731376,0.45017578287523974,0.7093027945185559,0.027281693661250963],"marker":{}}];
            var layout = {"width":500.0,"height":500.0};
            var config = {};
            Plotly.newPlot('22b1b3e5-1a0f-41b3-bf58-7daa7c4938b1', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_22b1b3e51a0f41b3bf587daa7c4938b1();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_22b1b3e51a0f41b3bf587daa7c4938b1();
            }
</script>
*)

