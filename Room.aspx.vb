﻿Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.DirectoryServices
Imports System.Configuration
Imports System.Web.Security
Imports System.Net

Public Class Room
    Inherits System.Web.UI.Page

    Dim ConnectionString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
         
        End If
    End Sub



Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim messageText As String = txtMessage.Text.Trim()
    Dim senderName As String = txtSenderName.Text.Trim()
    Dim recipientName As String = txtRecipientName.Text.Trim()

    ' Check if the message contains toxic words
    If Not ContainsToxicWords(messageText) Then
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO Messages (MessageText, SenderName, RecipientName, CreatedAt) VALUES (@MessageText, @SenderName, @RecipientName, @CreatedAt); SELECT SCOPE_IDENTITY()"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@MessageText", messageText)
                command.Parameters.AddWithValue("@SenderName", senderName)
                command.Parameters.AddWithValue("@RecipientName", recipientName)
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now)

                Dim messageId As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' Assuming you have a MessageId property in the Message class
                Dim message As New Message()
                message.MessageId = messageId
                message.MessageText = messageText
                message.SenderName = senderName
                message.RecipientName = recipientName
                message.CreatedAt = DateTime.Now




                
                ' ... do something with the message object if needed ...
                successMessage.Visible = True
                errorMessage.Visible = False
            End Using
        End Using
    Else
        ' Handle the case where the message contains toxic words
        ' For example, display an error message to the user
        errorMessage.Visible = True
        successMessage.Visible = False
    End If

    txtMessage.Text = ""
    txtSenderName.Text = ""
    txtRecipientName.Text = ""
End Sub

Private Function ContainsToxicWords(ByVal message As String) As Boolean
        ' Define a list of toxic words
        Dim toxicWords As String() = {
"2g1c",
"2 girls 1 cup",
"acrotomophilia",
"alabama hot pocket",
"alaskan pipeline",
"anal",
"anilingus",
"anus",
"apeshit",
"arsehole",
"ass",
"asshole",
"assmunch",
"auto erotic",
"autoerotic",
"babeland",
"baby batter",
"baby juice",
"ball gag",
"ball gravy",
"ball kicking",
"ball licking",
"ball sack",
"ball sucking",
"bangbros",
"bangbus",
"bareback",
"barely legal",
"barenaked",
"bastard",
"bastardo",
"bastinado",
"bbw",
"bdsm",
"beaner",
"beaners",
"beaver cleaver",
"beaver lips",
"beastiality",
"bestiality",
"big black",
"big breasts",
"big knockers",
"big tits",
"bimbos",
"birdlock",
"bitch",
"bitches",
"black cock",
"blonde action",
"blonde on blonde action",
"blowjob",
"blow job",
"blow your load",
"blue waffle",
"blumpkin",
"bollocks",
"bondage",
"boner",
"boob",
"boobs",
"booty call",
"brown showers",
"brunette action",
"bukkake",
"bulldyke",
"bullet vibe",
"bullshit",
"bung hole",
"bunghole",
"busty",
"butt",
"buttcheeks",
"butthole",
"camel toe",
"camgirl",
"camslut",
"camwhore",
"carpet muncher",
"carpetmuncher",
"chocolate rosebuds",
"cialis",
"circlejerk",
"cleveland steamer",
"clit",
"clitoris",
"clover clamps",
"clusterfuck",
"cock",
"cocks",
"coprolagnia",
"coprophilia",
"cornhole",
"coon",
"coons",
"creampie",
"cum",
"cumming",
"cumshot",
"cumshots",
"cunnilingus",
"cunt",
"darkie",
"date rape",
"daterape",
"deep throat",
"deepthroat",
"dendrophilia",
"dick",
"dildo",
"dingleberry",
"dingleberries",
"dirty pillows",
"dirty sanchez",
"doggie style",
"doggiestyle",
"doggy style",
"doggystyle",
"dog style",
"dolcett",
"domination",
"dominatrix",
"dommes",
"donkey punch",
"double dong",
"double penetration",
"dp action",
"dry hump",
"dvda",
"eat my ass",
"ecchi",
"ejaculation",
"erotic",
"erotism",
"escort",
"eunuch",
"fag",
"faggot",
"fecal",
"felch",
"fellatio",
"feltch",
"female squirting",
"femdom",
"figging",
"fingerbang",
"fingering",
"fisting",
"foot fetish",
"footjob",
"frotting",
"fuck",
"fuck buttons",
"fuckin",
"fucking",
"fucktards",
"fudge packer",
"fudgepacker",
"futanari",
"gangbang",
"gang bang",
"gay sex",
"genitals",
"giant cock",
"girl on",
"girl on top",
"girls gone wild",
"goatcx",
"goatse",
"god damn",
"gokkun",
"golden shower",
"goodpoop",
"goo",
"goregasm",
"grope",
"group sex",
"g-spot",
"guro",
"hand job",
"handjob",
"hard core",
"hardcore",
"hentai",
"homoerotic",
"honkey",
"hooker",
"horny",
"hot carl",
"hot chick",
"how to kill",
"how to murder",
"huge fat",
"humping",
"incest",
"intercourse",
"jack off",
"jail bait",
"jailbait",
"jelly donut",
"jerk off",
"jigaboo",
"jiggaboo",
"jiggerboo",
"jizz",
"juggs",
"kike",
"kinbaku",
"kinkster",
"kinky",
"knobbing",
"leather restraint",
"leather straight jacket",
"lemon party",
"livesex",
"lolita",
"lovemaking",
"make me come",
"male squirting",
"masturbate",
"masturbating",
"masturbation",
"menage a trois",
"milf",
"missionary position",
"mong",
"motherfucker",
"mound of venus",
"mr hands",
"muff diver",
"muffdiving",
"nambla",
"nawashi",
"negro",
"neonazi",
"nigga",
"nigger",
"nig nog",
"nimphomania",
"nipple",
"nipples",
"nsfw",
"nsfw images",
"nude",
"nudity",
"nutten",
"nympho",
"nymphomania",
"octopussy",
"omorashi",
"one cup two girls",
"one guy one jar",
"orgasm",
"orgy",
"paedophile",
"paki",
"panties",
"panty",
"pedobear",
"pedophile",
"pegging",
"penis",
"phone sex",
"piece of shit",
"pikey",
"pissing",
"piss pig",
"pisspig",
"playboy",
"pleasure chest",
"pole smoker",
"ponyplay",
"poof",
"poon",
"poontang",
"punany",
"poop chute",
"poopchute",
"porn",
"porno",
"pornography",
"prince albert piercing",
"pthc",
"pubes",
"pussy",
"queaf",
"queef",
"quim",
"raghead",
"raging boner",
"rape",
"raping",
"rapist",
"rectum",
"reverse cowgirl",
"rimjob",
"rimming",
"rosy palm",
"rosy palm and her 5 sisters",
"rusty trombone",
"sadism",
"santorum",
"scat",
"schlong",
"scissoring",
"semen",
"sex",
"sexcam",
"sexo",
"sexy",
"sexual",
"sexually",
"sexuality",
"shaved beaver",
"shaved pussy",
"shemale",
"shibari",
"shit",
"shitblimp",
"shitty",
"shota",
"shrimping",
"skeet",
"slanteye",
"slut",
"s&m",
"smut",
"snatch",
"snowballing",
"sodomize",
"sodomy",
"spastic",
"spic",
"splooge",
"splooge moose",
"spooge",
"spread legs",
"spunk",
"strap on",
"strapon",
"strappado",
"strip club",
"style doggy",
"suck",
"sucks",
"suicide girls",
"sultry women",
"swastika",
"swinger",
"tainted love",
"taste my",
"tea bagging",
"threesome",
"throating",
"thumbzilla",
"tied up",
"tight white",
"tit",
"tits",
"titties",
"titty",
"tongue in a",
"topless",
"tosser",
"towelhead",
"tranny",
"tribadism",
"tub girl",
"tubgirl",
"tushy",
"twat",
"twink",
"twinkie",
"two girls one cup",
"undressing",
"upskirt",
"urethra play",
"urophilia",
"vagina",
"venus mound",
"viagra",
"vibrator",
"violet wand",
"vorarephilia",
"voyeur",
"voyeurweb",
"voyuer",
"vulva",
"wank",
"wetback",
"wet dream",
"white power",
"whore",
"worldsex",
"wrapping men",
"wrinkled starfish",
"xx",
"xxx",
"yaoi",
"yellow showers",
"yiffy",
"zoophilia",
"13.",
"13点",
"三级片",
"下三烂",
"下贱",
"个老子的",
"九游",
"乳",
"乳交",
"乳头",
"乳房",
"乳波臀浪",
"交配",
"仆街",
"他奶奶",
"他奶奶的",
"他奶娘的",
"他妈",
"他妈ㄉ王八蛋",
"他妈地",
"他妈的",
"他娘",
"他马的",
"你个傻比",
"你他马的",
"你全家",
"你奶奶的",
"你她马的",
"你妈",
"你妈的",
"你娘",
"你娘卡好",
"你娘咧",
"你它妈的",
"你它马的",
"你是鸡",
"你是鸭",
"你马的",
"做爱",
"傻比",
"傻逼",
"册那",
"军妓",
"几八",
"几叭",
"几巴",
"几芭",
"刚度",
"刚瘪三",
"包皮",
"十三点",
"卖B",
"卖比",
"卖淫",
"卵",
"卵子",
"双峰微颤",
"口交",
"口肯",
"叫床",
"吃屎",
"后庭",
"吹箫",
"塞你公",
"塞你娘",
"塞你母",
"塞你爸",
"塞你老师",
"塞你老母",
"处女",
"外阴",
"大卵子",
"大卵泡",
"大鸡巴",
"奶",
"奶奶的熊",
"奶子",
"奸",
"奸你",
"她妈地",
"她妈的",
"她马的",
"妈B",
"妈个B",
"妈个比",
"妈个老比",
"妈妈的",
"妈比",
"妈的",
"妈的B",
"妈逼",
"妓",
"妓女",
"妓院",
"妳她妈的",
"妳妈的",
"妳娘的",
"妳老母的",
"妳马的",
"姘头",
"姣西",
"姦",
"娘个比",
"娘的",
"婊子",
"婊子养的",
"嫖娼",
"嫖客",
"它妈地",
"它妈的",
"密洞",
"射你",
"射精",
"小乳头",
"小卵子",
"小卵泡",
"小瘪三",
"小肉粒",
"小骚比",
"小骚货",
"小鸡巴",
"小鸡鸡",
"屁眼",
"屁股",
"屄",
"屌",
"巨乳",
"干x娘",
"干七八",
"干你",
"干你妈",
"干你娘",
"干你老母",
"干你良",
"干妳妈",
"干妳娘",
"干妳老母",
"干妳马",
"干您娘",
"干机掰",
"干死CS",
"干死GM",
"干死你",
"干死客服",
"幹",
"强奸",
"强奸你",
"性",
"性交",
"性器",
"性无能",
"性爱",
"情色",
"想上你",
"懆您妈",
"懆您娘",
"懒8",
"懒八",
"懒叫",
"懒教",
"成人",
"我操你祖宗十八代",
"扒光",
"打炮",
"打飞机",
"抽插",
"招妓",
"插你",
"插死你",
"撒尿",
"操你",
"操你全家",
"操你奶奶",
"操你妈",
"操你娘",
"操你祖宗",
"操你老妈",
"操你老母",
"操妳",
"操妳全家",
"操妳妈",
"操妳娘",
"操妳祖宗",
"操机掰",
"操比",
"操逼",
"放荡",
"日他娘",
"日你",
"日你妈",
"日你老娘",
"日你老母",
"日批",
"月经",
"机八",
"机巴",
"机机歪歪",
"杂种",
"浪叫",
"淫",
"淫乱",
"淫妇",
"淫棍",
"淫水",
"淫秽",
"淫荡",
"淫西",
"湿透的内裤",
"激情",
"灨你娘",
"烂货",
"烂逼",
"爛",
"狗屁",
"狗日",
"狗狼养的",
"玉杵",
"王八蛋",
"瓜娃子",
"瓜婆娘",
"瓜批",
"瘪三",
"白烂",
"白痴",
"白癡",
"祖宗",
"私服",
"笨蛋",
"精子",
"老二",
"老味",
"老母",
"老瘪三",
"老骚比",
"老骚货",
"肉壁",
"肉棍子",
"肉棒",
"肉缝",
"肏",
"肛交",
"肥西",
"色情",
"花柳",
"荡妇",
"賤",
"贝肉",
"贱B",
"贱人",
"贱货",
"贼你妈",
"赛你老母",
"赛妳阿母",
"赣您娘",
"轮奸",
"迷药",
"逼",
"逼样",
"野鸡",
"阳具",
"阳萎",
"阴唇",
"阴户",
"阴核",
"阴毛",
"阴茎",
"阴道",
"阴部",
"雞巴",
"靠北",
"靠母",
"靠爸",
"靠背",
"靠腰",
"驶你公",
"驶你娘",
"驶你母",
"驶你爸",
"驶你老师",
"驶你老母",
"骚比",
"骚货",
"骚逼",
"鬼公",
"鸡8",
"鸡八",
"鸡叭",
"鸡吧",
"鸡奸",
"鸡巴",
"鸡芭",
"鸡鸡",
"龟儿子",
"龟头",
"𨳒",
"陰莖",
"㞗",
"尻",
"𨳊",
"鳩",
"𡳞",
"𨶙",
"撚",
"𨳍",
"柒",
"閪",
"仆街",
"咸家鏟",
"冚家鏟",
"咸家伶",
"冚家拎",
"笨實",
"粉腸",
"屎忽",
"躝癱",
"你老闆",
"你老味",
"你老母",
"硬膠",
"光復香港時化革命",
"光時",
"五一",
"願榮光",
"願榮光歸香港",
"光復香港",
"時代革命",
"GFHG",
"SDGM",
"32190246",
"3219 0246",
"港獨",
"五大訴求",
 "缺一不可"
    }

        ' Check if the message contains any of the toxic words
        For Each word As String In toxicWords
        If message.ToLower().Contains(word) Then
            Return True
        End If
    Next

    Return False
End Function

End Class



Public Class Message
    Public Property MessageId As Integer
    Public Property MessageText As String
    Public Property CreatedAt As DateTime
    Public Property SenderName As String
    Public Property RecipientName As String
End Class