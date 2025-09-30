<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrokerWeb.Backend.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="ar-eg">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>عقار ستوك - عقارات للتداول في جميع مدن مصرعقار ستوك : سوق تداول العقارات | التجمع
        | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate
        Stock</title>
    <meta name="title" content="عقار ستوك-عقارات للتداول في جميع مدن مصر - Egypt Real Estate Stock : Cairo, Alexandria, Northcoast - AqarStock.com" />
    <meta name="description" content="عقار ستوك سوق ومحرك بحث عقاري يوفر لك وسيلة من اى مكان فى مصر لبيع وشراء العقارات . تصفح العقارات من موبيلك بكل سهولة." />
    <meta name="keywords" content="عقارات, خريطة, جوجل إرث, فيلا, بيت, منزل, شقة, أرض, قصر, غرفة, للبيع, شراء, مطلوب, تأجير, الرياض, السعودية, دبي, أبو ظبي, الدوحة, مصر, القاهرة, اسكندرية, شقق للب" />
    <meta name='twitter:card' content="summary" />
    <meta name='twitter:title' content="عقار ستوك" />
    <meta name='twitter:url' content="http://www.aqarstock.com/" />
    <meta name='twitter:description' content="عقار ستوك سوق ومحرك بحث عقاري يوفر لك وسيلة من اى مكان فى مصر لبيع وشراء العقارات . تصفح العقارات من موبيلك بكل سهولة." />
    <meta name='twitter:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:type' content="article" />
    <meta name='og:title' content="عقار ستوك" />
    <meta name='og:image' content="http://www.aqarstock.com/images/sociallogo.png" />
    <meta name='og:url' content="http://www.aqarstock.com/" />
    <meta name='og:description' content="عقار ستوك سوق ومحرك بحث عقاري يوفر لك وسيلة من اى مكان فى مصر لبيع وشراء العقارات . تصفح العقارات من موبيلك بكل سهولة." />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="../scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery.cycle2.min.js" type="text/javascript"></script>
    <link href="../styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.background').cycle({
                fx: 'fade',
                slides: '> div',
                timeout: 6000,
                speed: 2000

            });
        });
            
    </script>
    <!-- Facebook Conversion Code for Mastery House Visites -->
    <script>        (function () {
            var _fbq = window._fbq || (window._fbq = []);
            if (!_fbq.loaded) {
                var fbds = document.createElement('script');
                fbds.async = true;
                fbds.src = '//connect.facebook.net/en_US/fbds.js';
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(fbds, s);
                _fbq.loaded = true;
            }
            _fbq.push(['addPixelId', '923920740967751']);
        })();
        window._fbq = window._fbq || [];
        window._fbq.push(['track', 'PixelInitialized', {}]);
    </script>
    <noscript>
        <img height="1" width="1" alt="" style="display: none" src="https://www.facebook.com/tr?id=923920740967751&amp;ev=PixelInitialized" /></noscript>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtRegUserNamr">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblUserNameMsg" UpdatePanelRenderMode="Inline" />
                    <telerik:AjaxUpdatedControl ControlID="txtRegUserNamr" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblEmailMsg" UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnForgetPassword">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divForgetPasswordMsg" LoadingPanelID="radLoadingPannel"
                        UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--           <telerik:ajaxsetting ajaxcontrolid="btnRegister">
                        <updatedcontrols>
                            <telerik:ajaxupdatedcontrol controlid="register" loadingpanelid="radLoadingPannel" updatepanelrendermode="Inline" />
                           </updatedcontrols>
                    </telerik:ajaxsetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="radLoadingPannel" runat="server" HorizontalAlign="Left">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>
    <div class="background">
        <div class="backgroundUnit" style="background-image: url(../../images/backgrounds/1.jpg)">
        </div>
        <div class="backgroundUnit" style="background-image: url(../../images/backgrounds/2.jpg)">
        </div>
        <div class="backgroundUnit" style="background-image: url(../../images/backgrounds/3.jpg)">
        </div>
    </div>
    <div class="container loginPage">
        <div class="row">
            <ul class="nav nav-pills loginAndRegisterButtons">
                <li id="lilogin" class="active"><a data-toggle="tab" href="#login">الدخول</a> </li>
                <li id="liregister"><a data-toggle="tab" href="#register">التسجيل</a> </li>
            </ul>
            <div class="col-lg-12">
                <div class="panel-body">
                    <!-- Nav tabs -->
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div id="login" class="tab-pane fade in active">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="login-panel panel panel-default shadowPanel">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">
                                            تسجيل الدخول</h3>
                                    </div>
                                    <div class="panel-body">
                                        <fieldset>
                                        </fieldset>
                                        <div id="divMsg" runat="server" class="loginItem">
                                            <asp:Label ID="lblLoginMsg" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUserName" runat="server" class="form-control" autofocus="autofocus"
                                                placeholder="اسم المستخدم" ValidationGroup="login"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                                CssClass="Validator" ErrorMessage="!  من فضلك ادخل اسم المستخدم" ValidationGroup="login"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="كلمة السر"
                                                TextMode="Password" ValidationGroup="login"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                CssClass="Validator" ErrorMessage="!  من فضلك ادخل كلمة السر" ValidationGroup="login"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="btnLogin" runat="server" class="btn btn-lg btn-block btn-success"
                                                OnClick="btnLogin_Click" Text="دخول" ValidationGroup="login" />
                                        </div>
                                        <%--
                                                    <button class="btn btn-link btn-lg" data-toggle="modal" data-target="#myModal">
                                                                              نسيت كلمة السر؟
                                                                          </button>
                                        --%>
                                        <asp:HyperLink ID="HyperLink2" runat="server" class="btn btn-link btn-lg loginButton"
                                            data-target="#myModal" data-toggle="modal">
                            نسيت كلمة السر؟</asp:HyperLink>
                                        <a onclick="ShowRegister();" class="btn btn-link btn-lg loginButton">إنشاء حساب جديد</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="register" class="tab-pane fade">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="panel panel-default shadowPanel">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">
                                            التسجيل</h3>
                                    </div>
                                    <div class="panel-body">
                                        <fieldset>
                                            <div class="col-md-6 basicData regUnit">
                                                <h3>
                                                    البيانات الشخصية</h3>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtFullName" runat="server" class="form-control" autofocus="autofocus"
                                                        placeholder="الاسم  بالكامل" ValidationGroup="login"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل الاسم" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" autofocus="autofocus"
                                                        placeholder="رقم الموبيل" ValidationGroup="Register"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMobileNo"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل رقم الموبيل"
                                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="رقم الموبيل غير صحيح" ValidationExpression="([0-9]+\-?)*[0-9]+"
                                                        ValidationGroup="Register"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" autofocus="autofocus"
                                                        AutoPostBack="True" OnTextChanged="txtEmail_TextChanged" placeholder="البريد الالكترونى"
                                                        ValidationGroup="Register"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل البريد الالكترونى"
                                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="البريد الالكترونى غير صحيح"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                                    <asp:Label ID="lblEmailMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 regUnit">
                                                <h3>
                                                    بيانات الحساب <span>سيتم إستخدامها في تسجيل دخولك</span></h3>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtRegUserNamr" runat="server" class="form-control" autofocus="autofocus"
                                                        AutoPostBack="True" OnTextChanged="txtRegUserNamr_TextChanged" placeholder="اسم المستخدم"
                                                        ValidationGroup="Register"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRegUserNamr"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل اسم المستخدم"
                                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRegUserNamr" CssClass="Validator" Display="Dynamic" ValidationExpression="[a-zA-Z0-9]" ErrorMessage="! اسم المستخدم يجب ان يكون باللغة الأنجليزية و يتكون من حروف و ارقام فقط"></asp:RegularExpressionValidator>--%>
                                                    <asp:Label ID="lblUserNameMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtRegPassword" runat="server" class="form-control" placeholder="كلمة السر"
                                                        TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRegPassword"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل كلمة السر"
                                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRegPassword"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                                                        ValidationExpression="^.{6,32}$" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" placeholder="تاكيد كلمة السر"
                                                        TextMode="Password" ValidationGroup="Register"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfirmPassword"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!  من فضلك ادخل تاكيد كلمة السر"
                                                        ValidationGroup="Register"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtRegPassword"
                                                        ControlToValidate="txtConfirmPassword" CssClass="Validator" Display="Dynamic"
                                                        ErrorMessage="كلمة السر غير مطابقة" ValidationGroup="Register"></asp:CompareValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:CheckBox ID="chkTerms" runat="server" Checked="true" />
                                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-link btn-lg" data-target="#divConditions"
                                                        data-toggle="modal">
                          أوافق على الشروط و القوانين</asp:HyperLink>
                                                    <%--
                                                                <button class="btn btn-link btn-lg" data-toggle="modal" data-target="#divConditions">
                                                                                      أوافق على الشروط و القوانين
                                                                                  </button>
                                                    --%>
                                                    <br />
                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateCheckBox"
                                                        CssClass="Validator" Display="Dynamic" ErrorMessage="!يجب الموافقة على الشروط و القوانين قبل التسجيل"
                                                        ValidationGroup="Register"></asp:CustomValidator>
                                                </div>
                                                <div class="form-group  col-md-offset-1">
                                                    <asp:Button ID="btnRegister" runat="server" class="btn btn-lg btn-block btn-success"
                                                        OnClick="btnRegister_Click" Text="تسجيل" ValidationGroup="Register" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div id="myModal" class="modal fade pull-right" aria-hidden="true" aria-labelledby="myModalLabel"
        dir="rtl" role="dialog" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close pull-left" aria-hidden="true" data-dismiss="modal" type="button">
                        &times;</button>
                    <h4 id="myModalLabel" class="modal-title">
                        ادخل اسم المستخدم او الايميل و سيتم ارسال كلمة السر الى الايميل الخاص بك
                    </h4>
                </div>
                <div class="modal-body login">
                    <div id="divForgetPasswordMsg" runat="server" class="loginItem">
                        <asp:Label ID="lblForgetPasswordMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtFPUserName" runat="server" class="form-control" autofocus="autofocus"
                            placeholder="اسم المستخدم"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtFPEmail" runat="server" class="form-control" autofocus="autofocus"
                            placeholder="البريد الالكترونى" ValidationGroup="ForgetPassword"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFPEmail"
                            CssClass="Validator" Display="Dynamic" ErrorMessage="البريد الالكترونى غير صحيح"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ForgetPassword"></asp:RegularExpressionValidator>
                        <asp:Label ID="Label1" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--
                                <button type="button" class="btn btn-primary">
                                                 Save changes</button>
                    --%>
                    <asp:Button ID="btnForgetPassword" runat="server" class="btn btn-success" OnClick="btnForgetPassword_Click"
                        Text="ارسال" ValidationGroup="ForgetPassword" />
                    <button class="btn btn-default" data-dismiss="modal" type="button">
                        اغلاق</button>
                </div>
            </div>
        </div>
    </div>
    <div id="divConditions" class="modal fade pull-right" aria-hidden="true" aria-labelledby="myModalLabel"
        dir="rtl" role="dialog" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close pull-left" aria-hidden="true" data-dismiss="modal" type="button">
                        &times;</button>
                    <h4 id="H1" class="modal-title">
                        الشروط و القوانين
                    </h4>
                </div>
                <div class="modal-body login">
                    <ul>
                        <li>يتمتع عقار ستوك بكامل الصلاحية في حق التغيير أو التبديل أو الزيادة أو النقصان في
                            أي جزء من هذا الاتفاق، كاملا أو جزئيا، وفي أي وقت كان، وسيتم الإعلان عن أي تعديل
                            يطرأ على هذا الاتفاق. </li>
                        <li>بإمكان عقار ستوك تغيير أو تعليق أو توقيف أي جانب من محتويات عقار ستوك في أي وقت
                            كان، بما في ذلك المحتويات، وقواعد البيانات التي تشتمل عليها عقار ستوك . </li>
                        <li>بإمكان عقار ستوك أيضا فرض حدود على محتويات أوخدمات معينة أو تحديد شروط لدخولك موقع
                            عقار ستوك أو أي جزء من أجزائه من دون إعلان أو مسئولية قانونية. </li>
                        <li>في حالة حدوث خلاف بين الطرفين بشأن تنفيذ ما ورد بهذا الإتفاق تختص محاكم الإسكندرية
                            أو أي محكمة أخري مختصة بالنظر فيه خلاف ما يختص به القضاء المستعجل. </li>
                        <li>بإمكان عقار ستوك إجراء مراقبة على محتويات الموقع، والتصرف بحرية بالمعلومات أو المواد
                            التي ترسل إليه من طرفك أو تجمع أثناء استعمالك لعقار ستوك، ويمكن للموقع الكشف عن
                            أي معلومات في أية حالة يخولها القانون. </li>
                        <li>عند قيامك ببعث رسائل أو إرسال ملفات أو إدخال بيانات أو إجراء أي شكل من أشكال الاتصال
                            "اتصالات" (فردية أو جماعية) ، فإنك تمنح بذلك لـ"عقار ستوك" كامل الحق في استعمال
                            هذه "المشاركات" بنسخها وترخيصها وتكييفها وتوزيعها وكشفها وإبدائها للعموم وإعادة
                            إنشائها وتبليغها وتعديلها وتحريرها واستخدامها للاستفادة منها في كل مجال من مجالات
                            الإعلام المعروفة اليوم أو المطورة فيما بعد، وذلك بشكل دائم وعالمي ونهائي ولا محدود
                            وغير استثنائي وحر. وبموجب هذا، تتنازل عن كل الحقوق في أي ادعاء ضد عقار ستوك (aqarstock.com
                            ) يتعلق بأي خرق كان، حقيقيا أو مزعوما، فيما يخص أي حق من حقوق الملكية، وحقوق السرية
                            والإعلان، والحقوق الأخلاقية، وحقوق النسبة المعلقة بتلك المشاركات . تعترف بأن هذه
                            المشاركات الموجهة من وإلى عقار ستوك ليست سرية، ومن ثمة يمكن الاطلاع على اتصالاتك
                            وقراءتها من قبل الآخرين. تعترف بأنه عند إرسالكم هذه المشاركات إلى عقار ستوك، لا
                            ترتبط بعقار ستوك بأية علاقة سرية أو مالية أو تعاقدية ضمنية أو غيرها ما عدا العلاقة
                            التي يخولها لكم هذا الاتفاق. </li>
                    </ul>
                    <b>قبول شروط الخدمة: </b></br>
                    <p>
                        يسري هذا الاتفاق بينك وبين عقار ستوك. إن استعمالك للموقع الإلكتروني الخاص بـ"فـ
                        الدليل" يعني موافقتك على شروط الخدمة المبينة أدناه. فباستخدامك لموقع "عقار ستوك"
                        تقر بأنك قرأت شروط الخدمة وبأنك وافقت عليها. إذا كنت لا توافق على هذه الشروط الخاصة
                        بالاستعمال لا يسمح لك بدخول أو استعمال عقار ستوك.
                    </p>
                    <b>حساب العضوية وكلمة السر وتدابير الحماية: </b></br>
                    <p>
                        ستقوم باختيار كلمة السر خاصة بك أنت المسؤول عن إبقاءها سرية، وبناء عليه تتحمل المسئولية
                        الكاملة عن كل ما يمكن أن يحدث لكلمة السر أو الحساب الذي تمتلكه، وبذلك توافق على:
                        <ul>
                            <li>إعلام إدارة دار فوراً عن أي استعمال غير مشروع لكلمة السر أو الحساب الذي بحوزتك أو
                                أي خرق آخر لتدابير الحماية وإيقاف الحساب دون معاودة فتح هذا الحساب ويمكنك إنشاء
                                حساب آخر. </li>
                            <li>تعمل على تأكيد خروجك من حسابك عند انتهاء من عملك على الموقع. ولا تتحمل عقار ستوك
                                أية مسئولية في حال أي ضياع أو إتلاف يمكن أن ينتج عن عدم التزامك بهذه الفقرة.
                            </li>
                        </ul>
                    </p>
                    <b>سياسة الخصوصية: </b></br>
                    <p>
                        إن بيانات التسجيل وبعض المعلومات الأخرى التي تتعلق بك تندرج تحت سياسة الخصوصية التي
                        تتبعها عقار ستوك، ولن يتم مشاركة المعلومات الشخصية التي تقوم بتقديمها على هذا الموقع
                        خارج عقار ستوك إلا بعد الحصول على إذن منك.
                    </p>
                    <b>سلوك العضوية: </b></br>
                    <p>
                        إنك تمثل وتضمن وتتعهد بما يلي :
                        <ul>
                            <li>لن تعمل على سحب أو بعث أو إيصال أو توزيع أو نشر أي مادة من المواد المتوفرة على فـ
                                الدليل، والتي من شأنها :
                                <ul>
                                    <li>أن تحد أو تمنع أي مستعمل آخر من استعمال الموقع والاستفادة من محتوياته. </li>
                                    <li>أن تخرق القانون أو تحمل تهديدا أو عدوانا أو سبا أو قدحا أو تصرفا فاحشا غير أخلاقي
                                        أو تهجما أو خروجا عن الآداب والأخلاق. </li>
                                    <li>أن تدفع إلى القيام بسلوك يعتبر تعديا إجراميا أو تشجع عليه، مما من شأنه أن يؤدي إلى
                                        المسئولية المدنية أو أي شكل من أشكال خرق القانون. </li>
                                    <li>أن تتعدى على حقوق أطراف أخرى ثالثة أو تسرق أو تتجاوز هذه الحقوق المتعلقة بكل حقوق
                                        الملكية الفكرية بدون حدود، والحقوق التجارية المسجلة وحقوق براءات الاختراع والحقوق
                                        الخاصة والعامة أو أي حق من حقوق الملكية. </li>
                                    <li>أن تشتمل تلك المواد على فيروس معلوماتي أو أي شيء آخر ضار بالموقع. </li>
                                    <li>أن تتوفر على أي معلومات أو برامج معلوماتية أو غيرها من المواد ذات الطبيعة التجارية.
                                    </li>
                                    <li>أن تشتمل على أي إعلان أو دعاية كيفما كانت. </li>
                                    <li>أو أن تشكل أو تتوفر على إشارات خاطئة أو مضللة لها صلة بمصدر معلومات أو أخبار.
                                    </li>
                                </ul>
                            </li>
                            <li>يجب الإطلاع والموافقة على شروط التسجيل بموقع عقار ستوك، وتسجيلك بموقع عقار ستوك
                                يعني موافقتك والتزامك بشروط التسجيل والمشاركة وعند خرق اي من هذه الشروط يحق لإدارة
                                عقار ستوك ايقاف او الغاء عضويتك فوراً. </li>
                        </ul>
                    </p>
                    <b>التعويضات :</b></br>
                    <p>
                        بموجب هذا العقد توافق على تعويض عقار ستوك والدفاع عنه وإبعاد الضرر عنه وكل ما من
                        شأنه أن يؤدي إلى إلحاق المسئولية والخسائر بالموقع وكل المسئولين عليه ومديريه ومالكيه
                        ووكلائه والعاملين به ومزوديه بالأخبار والمواضيع وفروعه ومرخصيه والمرخص لهم فيه،
                        وعموما، "الأطراف التي يتم تعويضها" عن كل المساءلات والخسائر التي تلحق به فيما يخص
                        أي ادعاء ناجم عن أي خرق من جهتك لهذا الاتفاق أو لأي شكل من أشكال الاتفاقات والضمانات
                        والتعاقدات المقبلة، بما فيها كل مصاريف قضائية معقولة ناتجة أو لها صلة بأي ادعاء
                        من الادعاءات. ويحتفظ عقار ستوك بالحق، على مسئوليته الخاصة، في تحمل أعباء الدفاع
                        والتقرير في أي مسألة من المسائل التي تتعلق بتعويضك، وبموجب هذا لا يسمح لك في أي
                        ظرف من الظروف التقرير في أي أمر دون التوصل بالموافقة الكتابية من عقار ستوك.
                    </p>
                    <b>إخلاء المسئولية</b></br>
                    <p>
                        يلتزم عقار ستوك بأن كل ما يتوفر به من محتويات وأنظمة معلوماتية ووظائف ومواد ومعلومات
                        مقدمة على الموقع، معروضة "كما هي" حسب أقصى ما يسمح به القانون. ولا يقدم عقار ستوك،
                        ولا أي من توابعه أو فروعه، أي تمثيل أو ضمانات كيفما كانت لها صلة بمحتوى عقار ستوك
                        أو أي من المواد والمعلومات والوظائف القابلة للاستعمال بواسطة الأنظمة المعلوماتية
                        المتوفرة على عقار ستوك. ولا يتحمل عقار ستوك أية مسئولية إزاء أي من المنتوجات أو
                        الخدمات أو الروابط الإلكترونية المتصلة بأطراف أخرى ثالثة، كما لا يتحمل مسئولية أي
                        انتهاك للأمان المرتبط بإرسال معلومات حساسة من خلال عقار ستوك أو أي رابط من روابطه.
                        وفوق ذلك، لا يمنح عقار ستوك أية ضمانات واضحة كانت أو مضمنة، تتعلق، دون استثناء،
                        بعدم القابلية للانتهاك أو سلامة شروط المتاجرة أو الصلاحية المتعلقة بأي أمر من الأمور.
                        ولا يضمن عقار ستوك بأن بيانات العقارات الموجودة على موقعه الإلكتروني أو أي من مواده
                        أو محتوياته خالية من الأخطاء. كما لا يضمن عقار ستوك بأن مثل تلك الأخطاء ستصحح، أو
                        بأن عقار ستوك أو النظام المعلوماتي الذي يعمل من خلاله سيكون خاليا من الفيروسات أو
                        أي شيء ضار. ولن يكون عقار ستوك، أو أي من توابعه أو فروعه، مسئول عن استعمال عقار
                        ستوك، بما في ذلك وبدون استثناء، المحتوى أو أي خطأ من الأخطاء المتواجدة به.
                    </p>
                    <b>الإتفاق الكامل : </b></br>
                    <p>
                        تمثل هذه الاتفاقية عقدًا كاملاً بينك وبين عقار ستوك ( aqarstock.com )، فيما يتعلق
                        باستخدامك لعقار ستوك . وإن أي دعوى ، حول أي تصرف يتعلق باستخدامك عقار ستوك ، يجب
                        أن ترفع خلال شهر من تقديمك الاعتراض، أو من نشوء سبب التصرف المذكور. وإذا اكتشفت
                        المحكمة القضائية المختصة، لأي سبب من الأسباب، عدم إمكانية تنفيذ أي بند من بنود الاتفاقية،
                        أو جزء منها، يتم تطبيق هذا البند بأقصى الحدود الجائزة والمصرح بها، بحيث يتم تنفيذ
                        مغزى الاتفاقية، على أن تبقى جميع الأحكام والبنود الأخرى للاتفاقية نافذة وسارية المفعول.
                        وتتنصل عقار ستوك عن تحمل أية مسئولية، لمضمون مواد أي طرف ثالث، المتوفرة عبر الوصلات
                        و الروابط الموجودة على عقار ستوك او المنشورة بواسطة أعضاء المنتديات.
                    </p>
                    <b>شمولية الاتفاقية</b></br>
                    <p>
                        يحتوي موقع " عقار ستوك " على روابط وإشارات إلى مواقع إنترنت أخرى، ومصادر في مختلف
                        أرجاء العالم، ووصلات بالراعين الرسميين او المعلنين، إن هذه الوصلات التي تصل بين
                        " عقار ستوك " وأي من المواقع الأخرى (وبالعكس)، والتي تدار من قبل طرف ثالث، لا تحمّل
                        " عقار ستوك " أو الطرف الثالث، أي مسئولية، ولا تمثل أي نوع من المصادقة على محتويات
                        تلك المواقع، كما أن " عقار ستوك " غير مسئول عن الآراء ووجهات النظر والأفكار والتصريحات
                        والمعلومات التي تُعرض فيه، أو توزع عبره، وهي لا تمثل وجهة نظر الموقع. ونحيطك علمًا
                        أن أي ركون إلى مثل هذه الآراء والنصائح ووجهات النظر والأفكار والتصريحات والتقارير
                        والمعلومات إنما يجري على مسئوليتك الشخصية. ويحتفظ عقار ستوك بحقه وفق تقديراته الخاصة
                        في تصحيح أية أخطاء أو خلل في أي جزء من موقع "عقار ستوك" ، ولا يقوم موقع "عقار ستوك"
                        ولا يستطيع مراجعة كل المواد المنشورة في صفحاته والتي يسجلها المستخدمون والزوار والأعضاء
                        وبالتالي فإن موقع "عقار ستوك" غير مسئول عن تلك المواد. ويحتفظ موقع " عقار ستوك"
                        بأية حال بحقه الدائم -وعند الضرورة- في كشف أية معلومات من شأنها أن تفيد العدالة
                        والنظام العام ومتطلبات الحكومة وكذلك في تدقيق أو تنقيح أو رفض أو محو أية مواد برمتها
                        أو بجزئياتها والتي يجدها عقار ستوك وفق تقديراته الخاصة، مستهجنة أو تتعارض مع بنود
                        هذا الاتفاق.
                    </p>
                    <b>بيانات العقارات:</b></br>
                    <p>
                        كل البيانات المعروضه عن العقارات في الموقع للإستخدام الشخصي والخاص للمستخدم ، و
                        الأستخدام الغير التجاري للمستخدم وغير متاحة لإعادة نشر البيانات أو الأرسال أو النسخ.
                        لا يجوز للمستخدم بيع أو استخدام بيانات العقارات لغرض غير الغرض من محاولة تقييم العقار
                        أو العقارات للبيع أو الشراء.
                    </p>
                    <b>الإلغاء:</b></br>
                    <p>
                        عقار ستوك لديه الحق بمنع أو ألغاء دخول المستخدم إلى الموقع أو وقف التعامل مع اي
                        شخص في حاله ثبوت استخدامه الألفاظ النابية ، الفحش ، التهديد ، المضايقة ، التشهيرية
                        ، البغيضه ، المسيئة بأي طريقة كانت أو التعرض بأي شكل من الأشكال تجاه اي موظف في
                        عقار ستوك سوءاً على الموقع ، البريد الألكتروني ، المكالمات التلفونية أو الرسائل
                        ، في الكتابة ، أو في الشخص.
                    </p>
                    <b>إستخدام محتوى الموقع</b></br>
                    <p>
                        يمكنك تحميل ، عرض ، وطباعة نسخة من اي مضمون آخر ، فقط لأغراضك الشخصية وغير التجارية
                        ، ويخضع للقوانين والقيود المنصوص عليها في هذا الأتفاقية "إتفاقية الأستخدام". الأسم
                        ، الشعار ، وكل المحتويات التي تظهر على موقع عقار ستوك ، سوف تظل ملكاً خاصاً لموقع
                        عقار ستوك ومرخصيها. بإستثناء ماهو ماهو مسموح به صراحة في هذا الأتفاق ، ولا يجوز
                        لك استخدام أو تعديل أو إعداد أعمال اشتقاقيه تستند إلى توزيع أو بيع أو نقل أو عرض
                        أو اي طريقة بإستخدام موقع عقار ستوك ، أو اي محتوى ظاهر في موقع عقار ستوك.
                    </p>
                    <b>الخدمات المدفوعة</b></br>
                    <ul>
                        <li>يلتزم العميل بكافة شروط الاستخدام، وفي حالة المخالفة يحق لإدارة الموقع حذف الإعلانات
                            المخالفة بدون تعويض. </li>
                        <li>يحق لإدارة موقع عقارماب تغيير شروط الإعلان على الموقع في أي وقت دون سابق إنذار،
                            وتصبح هذه الشروط فعالة وملزمة لكافة العملاء مباشرة. لهذا، يقر العميل بالتزامه بشروط
                            الإعلان الحالية والمستقبلية، ونذكر على سبيل المثال وليس الحصر شكل الإعلان ومحتواه
                            وكيفية عرضه ومدة الإعلان وعدد النقاط المطلوبة لكل الإعلان. </li>
                        <li>يلتزم العميل بعدم وضع أي محتوى في الموقع يخالف الأداب أو القانون، كما يلتزم بأنه
                            المسؤول قانونياً بشأن أي محتوى يتم وضعه على الموقع من صور وبيانات وأرقام وأسعار،
                            وفي حالة مخالفة العميل للقوانين أو لحقوق ملكية شخص أو أي جهة يحق لإدارة الموقع حذف
                            المحتوى المخالف بدون تعويض العميل عن النقاط المستخدمة. </li>
                        <li>تنتهي صلاحية النقاط بعد عام كامل من تاريخ الشراء، ولا يحق للعميل المطالبة باستخدام
                            النقاط وإسترجاع قيمتها بعد تاريخ الإنتهاء. </li>
                        <li>يحق للعميل المطالبة باسترجاع قيمة النقاط المتبقية في حسابه قبل مرور عام كامل من
                            تاريخ الشراء، وفي هذه الحالة يتم خصم الرسوم الإدارية بما يعادل ٢٠٪ من قيمة الشراء
                            الإجمالية التي تم دفعها يوم الاشتراك. </li>
                        <li>فى حالة وقوع اى خطا فى نشر جزء او كل الاعلان الخاص بالعميل او حذف جزء من الاعلان
                            فيقدر حجم الضرر بقيمة تقديرية لاتزيد عن قيمة الاعلان الاجمالية ولا تكون إدارة عقارماب
                            مسؤولة عن اية اضرار اخرى قد تحدث للعميل من جراء هذا الخطا. </li>
                        <li>إدارة الموقع غير مسؤولة عن أي أخطاء يقوم بها العميل تسبب فقدانه للنقاط التي قام
                            بشراءها، وفور استخدام النقاط لا يمكن استرجاعها بأي حال من الأحوال. </li>
                        <li>يحق للإدارة في أي وقت إنهاء التعامل بنظام النقاط، وفي هذه الحالة تلتزم الشركة بدفع
                            القيمة الكاملة للنقاط المتبقية لكل عميل. </li>
                        <li>من المتوقع أن تتوقف خدمات موقع عقارماب لساعات وأحياناً لعدة أيام بسبب الصيانة أو
                            بسبب خطأ تقني أو لأي سبب آخر، وفي هذه الحالة لا يحق للعميل مطالبة الإدارة بأي تعويض
                            إلا لو كانت مدة التوقف قد تجاوزت ٧ أيام خلال شهر واحد، وفي هذه الحالة يتم تعويض
                            العميل بفترة تساوي فترة التوقف التي حدثت. </li>
                        <li>لا يحق للعميل الإعلان عن عقارات وهمية أو عقارات غير متوفرة أو استخدام أسعار غير
                            صحيحة أو قديمة أو وضع سعر غير السعر الكامل للعقار، وفي حالة مخالفة العميل لهذا الشرط
                            يحق للإدارة حذف الإعلان دون تعويض العميل عن قيمته، وفي حالة تكرار المخالفة يحق للإدارة
                            إغلاق حساب العميل وخصم ٢٠٪ من قيمة الحساب كغرامة لمخالفة شروط الاشتراك. </li>
                        <li>في حالة بيع عقار معلن عنه، يلتزم العميل بحذف الإعلان الخاص بهذا العقار خلال ٣ أيام
                            من تاريخ البيع، ولا يحق للعميل بالمطالبة بتعويض قيمة الإعلان </li>
                        <li>لا يحق للعميل استخدام النقاط التي قام بشراءها لخدمة عميل آخر وفي حالة حدوث ذلك يحق
                            لإدارة الموقع إغلاق حساب العميل وخصم ٢٠٪ من قيمة الحساب كغرامة لمخالفة شروط الاشتراك.
                        </li>
                        <li>إذا رأت إدارة الموقع أن أحد العملاء يحاول التلاعب بنظام النقاط أو نظام الموقع، فيحق
                            لها إغلاق حساب العميل مباشرة وخصم ٢٠٪ من قيمة الحساب كغرامة تلاعب. </li>
                        <li>لا يحق للعميل بيع النقاط لأي عميل أو فرد أو جهة أخرى، وفي حالة ثبوت ذلك، يحق لإدارة
                            الموقع إلغاء النقاط التي تم بيعها وإغلاق حساب العميل. </li>
                        <li>يحق للشركة رفض التعامل مع عميل معين بسبب أو بدون سبب، وفي حالة إغلاق حساب عميل بسبب
                            رغبة الشركة في إيقاف التعامل معه يتم دفع القيمة الكاملة للنقاط المتبقية للعميل.
                        </li>
                        <li>العميل مسؤول بشكل كامل على الحفاظ على سرية معلومات الدخول لحسابه في الموقع، لهذا
                            فإن إدارة الموقع غير مسؤولة عن اختراق حساب العميل أو استخدام شخص آخر لحسابه بدون
                            سابق إذنه، وتنصح الإدارة باستخدام العميل لكلمة مرور صعبة وفريدة لكي يتم حماية حساب
                            العميل بأفضل شكل ممكن. </li>
                    </ul>
                    <b>محتوى الموقع</b></br>
                    <p>
                        عقار ستوك يقدم/يوفر مجموعة متنوعة من المعلومات وعدد من الأدوات في الموقع لمساعدتك.
                        تعليقات وردود فعل المستخدمين في صفحات معلومات عقارات المستخدمين ، هي جزء من محتويات
                        موقع عقار ستوك من مستخدمي الموقع الذين اختارو إضافة تعليقاتهم وآرائهم على موقع فـ
                        الدليل. في حين تتوفر هذا التعليقات والإضافات للذين يرغبون في الأطلاع عليها ، فأنها
                        لاتعكس رأي إدارة موقع عقار ستوك ولا يضمن أو يؤيد موقع عقار ستوك دقة البيانات في
                        أي نشر على صفحات الموقع. مستخدمي موقع عقار ستوك يجب ان يدركو ان إدارة موقع عقار
                        ستوك لاتساهم في المضمون الوارد في التعليقات والآراء التي تنشر في صفحات الموقع من
                        قبل مستخدمي الموقع.
                    </p>
                    <b>لا ضمانة</b></br>
                    <p>
                        عقار ستوك يتنصل من اي وكافة الضمانات ، التي تتضمن بما في ذالك على سبيل المثال وليس
                        الحصر:
                        <ul>
                            <li>أي ضمانات فيما تتعلق بتوافر ودقة وفائدة البيانات ، أو محتوى أو الوصول إلى المعلومات
                                دون إنقطاع </li>
                            <li>إي ضمانات للأسماء والعناوين ـ وغير التعدي ، بالتسويق لغرض معين. هذا التنصل من المسؤلية
                                ينطق على أي اضرار أو إصابات تنجم عن أي قصور في الأداء أو خطأ أو أغفال أو انقطاع
                                أو حذف أو عيب أو التأخير في التشغيل أو الأرسال أو فيروسات الكمبيوتر ، فشل في الأتصال
                                ، السرقة ، الدمار ، أو الدخول غير المصرح به ، أو التعديلات في معلومات الدخول مع
                                استخدام أو تشغيل الخدمة ، سواء عن الأخلال في العقد ، السلوك التقصيري ، الأهمال ،
                                أو أي سبب آخر للعمل. </li>
                        </ul>
                    </p>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-default" data-dismiss="modal" type="button">
                        اغلاق</button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnIsRegister" runat="server" />
    </form>
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=chkTerms.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
        function ShowRegister() {
            $('#register').addClass("active in");
            $('#login').removeClass("active in");
            $('#liregister').addClass("active");
            $('#lilogin').removeClass("active");
        }
        var type = window.location.pathname.toString().replace('/', '');
        if (type == "Register") {
            ShowRegister();
        }
        var IsRegister = $("#<%=hdnIsRegister.ClientID %>").val();
        //  alert(IsRegister);
        if (IsRegister != null && IsRegister != "") {

            ShowRegister();
        }
        // alert(type);
    </script>
</body>
</html>
