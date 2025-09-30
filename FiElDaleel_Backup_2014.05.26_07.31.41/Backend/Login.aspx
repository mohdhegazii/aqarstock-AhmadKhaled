<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrokerWeb.Backend.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="ar-eg">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="../scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/Main.css" rel="stylesheet" type="text/css" />
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
                    <telerik:AjaxUpdatedControl ControlID="txtRegUserNamr" UpdatePanelRenderMode="Inline"
                        LoadingPanelID="radLoadingPannel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblEmailMsg" UpdatePanelRenderMode="Inline" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnForgetPassword">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divForgetPasswordMsg" UpdatePanelRenderMode="Inline"
                        LoadingPanelID="radLoadingPannel" />
                    <%--<telerik:AjaxUpdatedControl ControlID="lblForgetPasswordMsg" UpdatePanelRenderMode="Inline" LoadingPanelID="radLoadingPannel"/>--%>
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="radLoadingPannel" runat="server" HorizontalAlign="Left">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loading.gif" />
    </telerik:RadAjaxLoadingPanel>
    <div class="container pull-right">
        <div class="row pull-right">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 pull-right">
                <div class="login  input-group">
                    <h2 class="">
                        دخول</h2>
                    <div id="divMsg" runat="server" class="loginItem">
                        <asp:Label ID="lblLoginMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="login" class="form-control"
                            placeholder="اسم المستخدم" autofocus></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="login"
                            CssClass="Validator" ControlToValidate="txtUserName" runat="server" ErrorMessage="!  من فضلك ادخل اسم المستخدم"></asp:RequiredFieldValidator>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="كلمة السر"
                            class="form-control" ValidationGroup="login"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="login"
                            CssClass="Validator" ControlToValidate="txtPassword" runat="server" ErrorMessage="!  من فضلك ادخل كلمة السر"></asp:RequiredFieldValidator>
                    </div>
                    <div class="loginItem">
                        <asp:Button ID="btnLogin" class="btn btn-lg btn-block" runat="server" Text="دخول"
                            ValidationGroup="login" OnClick="btnLogin_Click" />
                    </div>
                    <div class="loginItem">
                      <%--  <button class="btn btn-link btn-lg" data-toggle="modal" data-target="#myModal">
                            نسيت كلمة السر؟
                        </button>--%>
                         <asp:HyperLink ID="HyperLink2" class="btn btn-link btn-lg" data-toggle="modal" data-target="#myModal" runat="server"> 
                            نسيت كلمة السر؟</asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 pull-right">
                <div class="login  input-group">
                    <h2 class="">
                        تسجيل</h2>
                    <div class="loginItem">
                        <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="login" class="form-control"
                            placeholder="الاسم " autofocus></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="txtFullName" runat="server" ErrorMessage="!  من فضلك ادخل الاسم"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtMobileNo" runat="server" ValidationGroup="Register" class="form-control"
                            placeholder="رقم الموبيل" autofocus></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="txtMobileNo" runat="server" ErrorMessage="!  من فضلك ادخل رقم الموبيل"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="رقم الموبيل غير صحيح"
                            ControlToValidate="txtMobileNo" ValidationGroup="Register" ValidationExpression="([0-9]+\-?)*[0-9]+"
                            CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Register" class="form-control"
                            placeholder="البريد الالكترونى" autofocus AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                       <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="txtEmail" Display="Dynamic" runat="server"
                            ErrorMessage="!  من فضلك ادخل البريد الالكترونى"></asp:RequiredFieldValidator>
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="البريد الالكترونى غير صحيح"
                            ControlToValidate="txtEmail" ValidationGroup="Register" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblEmailMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtRegUserNamr" runat="server" ValidationGroup="Register" class="form-control"
                            placeholder="اسم المستخدم" autofocus AutoPostBack="True" OnTextChanged="txtRegUserNamr_TextChanged"></asp:TextBox>
                       <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="txtRegUserNamr" Display="Dynamic" runat="server"
                            ErrorMessage="!  من فضلك ادخل اسم المستخدم"></asp:RequiredFieldValidator>
                       
                        <asp:Label ID="lblUserNameMsg" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" placeholder="كلمة السر"
                            class="form-control" ValidationGroup="Register"></asp:TextBox>
                      <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Register"
                            CssClass="Validator" ControlToValidate="txtRegPassword" Display="Dynamic" runat="server"
                            ErrorMessage="!  من فضلك ادخل كلمة السر"></asp:RequiredFieldValidator>
                      
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="من فضلك ادخل على الأقل 6 و 32 حرفا كحد أقصى"
                            ControlToValidate="txtRegPassword" ValidationGroup="Register" ValidationExpression="^.{6,32}$"
                            CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="تاكيد كلمة السر"
                            class="form-control" ValidationGroup="Register"></asp:TextBox>
                       <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="Register"
                            CssClass="Validator" Display="Dynamic" ControlToValidate="txtConfirmPassword"
                            runat="server" ErrorMessage="!  من فضلك ادخل تاكيد كلمة السر"></asp:RequiredFieldValidator>
                       
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة السر غير مطابقة"
                            ControlToCompare="txtRegPassword" ValidationGroup="Register" ControlToValidate="txtConfirmPassword"
                            Display="Dynamic" CssClass="Validator"></asp:CompareValidator>
                    </div>
                    <div class="loginItem">
                        <asp:CheckBox ID="chkTerms" runat="server" Checked="true" />
                        <asp:HyperLink ID="HyperLink1" class="btn btn-link btn-lg" data-toggle="modal" data-target="#divConditions" runat="server"> 
                          أوافق على الشروط و القوانين</asp:HyperLink>
                  <%--      <button class="btn btn-link btn-lg" data-toggle="modal" data-target="#divConditions">
                            أوافق على الشروط و القوانين
                        </button>--%>
                        <br />
                        <asp:CustomValidator ID="CustomValidator1" ValidationGroup="Register" CssClass="Validator"
                            Display="Dynamic" ClientValidationFunction="ValidateCheckBox" runat="server"
                            ErrorMessage="!يجب الموافقة على الشروط و القوانين قبل التسجيل"></asp:CustomValidator>
                    </div>
                    <div class="loginItem">
                        <asp:Button ID="btnRegister" class="btn btn-lg btn-block" runat="server" Text="تسجيل"
                            ValidationGroup="Register" OnClick="btnRegister_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade pull-right" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true" dir="rtl">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close pull-left" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="myModalLabel">
                        ادخل اسم المستخدم او الايميل و سيتم ارسال كلمة السر الى الايميل الخاص بك
                    </h4>
                </div>
                <div class="modal-body login">
                    <div id="divForgetPasswordMsg" runat="server" class="loginItem">
                        <asp:Label ID="lblForgetPasswordMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtFPUserName" runat="server" class="form-control" placeholder="اسم المستخدم"
                            autofocus></asp:TextBox>
                    </div>
                    <div class="loginItem">
                        <asp:TextBox ID="txtFPEmail" runat="server" ValidationGroup="ForgetPassword" class="form-control"
                            placeholder="البريد الالكترونى" autofocus AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="البريد الالكترونى غير صحيح"
                            ControlToValidate="txtFPEmail" ValidationGroup="ForgetPassword" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            CssClass="Validator" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:Label ID="Label1" runat="server" CssClass="Validator" Text=""></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--       <button type="button" class="btn btn-primary">
                        Save changes</button>--%>
                    <asp:Button ID="btnForgetPassword" class="btn btn-primary" runat="server" Text="ارسال"
                        ValidationGroup="ForgetPassword" OnClick="btnForgetPassword_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        اغلاق</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade pull-right" id="divConditions" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true" dir="rtl">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close pull-left" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H1">
                        الشروط و القوانين
                    </h4>
                </div>
                <div class="modal-body login">
                    <ul>
                        <li>يتمتع فاليو بكامل الصلاحية في حق التغيير أو التبديل أو الزيادة أو النقصان في
                            أي جزء من هذا الاتفاق، كاملا أو جزئيا، وفي أي وقت كان، وسيتم الإعلان عن أي تعديل
                            يطرأ على هذا الاتفاق. </li>
                        <li>بإمكان فاليو تغيير أو تعليق أو توقيف أي جانب من محتويات فاليو في أي وقت
                            كان، بما في ذلك المحتويات، وقواعد البيانات التي تشتمل عليها فاليو . </li>
                        <li>بإمكان فاليو أيضا فرض حدود على محتويات أوخدمات معينة أو تحديد شروط لدخولك موقع
                            فاليو أو أي جزء من أجزائه من دون إعلان أو مسئولية قانونية. </li>
                        <li>في حالة حدوث خلاف بين الطرفين بشأن تنفيذ ما ورد بهذا الإتفاق تختص محاكم الإسكندرية
                            أو أي محكمة أخري مختصة بالنظر فيه خلاف ما يختص به القضاء المستعجل. </li>
                        <li>بإمكان فاليو إجراء مراقبة على محتويات الموقع، والتصرف بحرية بالمعلومات أو المواد
                            التي ترسل إليه من طرفك أو تجمع أثناء استعمالك لفـ الدليل، ويمكن للموقع الكشف عن
                            أي معلومات في أية حالة يخولها القانون. </li>
                        <li>عند قيامك ببعث رسائل أو إرسال ملفات أو إدخال بيانات أو إجراء أي شكل من أشكال الاتصال
                            "اتصالات" (فردية أو جماعية) ، فإنك تمنح بذلك لـ"فـ الدليل" كامل الحق في استعمال
                            هذه "المشاركات" بنسخها وترخيصها وتكييفها وتوزيعها وكشفها وإبدائها للعموم وإعادة
                            إنشائها وتبليغها وتعديلها وتحريرها واستخدامها للاستفادة منها في كل مجال من مجالات
                            الإعلام المعروفة اليوم أو المطورة فيما بعد، وذلك بشكل دائم وعالمي ونهائي ولا محدود
                            وغير استثنائي وحر. وبموجب هذا، تتنازل عن كل الحقوق في أي ادعاء ضد فاليو (fildalel.com
                            ) يتعلق بأي خرق كان، حقيقيا أو مزعوما، فيما يخص أي حق من حقوق الملكية، وحقوق السرية
                            والإعلان، والحقوق الأخلاقية، وحقوق النسبة المعلقة بتلك المشاركات . تعترف بأن هذه
                            المشاركات الموجهة من وإلى فاليو ليست سرية، ومن ثمة يمكن الاطلاع على اتصالاتك
                            وقراءتها من قبل الآخرين. تعترف بأنه عند إرسالكم هذه المشاركات إلى فاليو، لا
                            ترتبط بفـ الدليل بأية علاقة سرية أو مالية أو تعاقدية ضمنية أو غيرها ما عدا العلاقة
                            التي يخولها لكم هذا الاتفاق. </li>
                    </ul>
                    <b>قبول شروط الخدمة: </b></br>
                    <p>
                        يسري هذا الاتفاق بينك وبين فاليو. إن استعمالك للموقع الإلكتروني الخاص بـ"فـ
                        الدليل" يعني موافقتك على شروط الخدمة المبينة أدناه. فباستخدامك لموقع "فـ الدليل"
                        تقر بأنك قرأت شروط الخدمة وبأنك وافقت عليها. إذا كنت لا توافق على هذه الشروط الخاصة
                        بالاستعمال لا يسمح لك بدخول أو استعمال فاليو.
                    </p>
                    <b>حساب العضوية وكلمة السر وتدابير الحماية: </b></br>
                    <p>
                        ستقوم باختيار كلمة السر خاصة بك أنت المسؤول عن إبقاءها سرية، وبناء عليه تتحمل المسئولية
                        الكاملة عن كل ما يمكن أن يحدث لكلمة السر أو الحساب الذي تمتلكه، وبذلك توافق على:
                        <ul>
                            <li>إعلام إدارة فاليو فوراً عن أي استعمال غير مشروع لكلمة السر أو الحساب الذي بحوزتك
                                أو أي خرق آخر لتدابير الحماية وإيقاف الحساب دون معاودة فتح هذا الحساب ويمكنك إنشاء
                                حساب آخر. </li>
                            <li>تعمل على تأكيد خروجك من حسابك عند انتهاء من عملك على الموقع. ولا تتحمل فاليو
                                أية مسئولية في حال أي ضياع أو إتلاف يمكن أن ينتج عن عدم التزامك بهذه الفقرة.
                            </li>
                        </ul>
                    </p>
                    <b>سياسة الخصوصية: </b></br>
                    <p>
                        إن بيانات التسجيل وبعض المعلومات الأخرى التي تتعلق بك تندرج تحت سياسة الخصوصية التي
                        تتبعها فاليو، ولن يتم مشاركة المعلومات الشخصية التي تقوم بتقديمها على هذا الموقع
                        خارج فاليو إلا بعد الحصول على إذن منك.
                    </p>
                    <b>سلوك العضوية: </b></br><p>
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
                            <li>يجب الإطلاع والموافقة على شروط التسجيل بموقع فاليو، وتسجيلك بموقع فاليو
                                يعني موافقتك والتزامك بشروط التسجيل والمشاركة وعند خرق اي من هذه الشروط يحق لإدارة
                                فاليو ايقاف او الغاء عضويتك فوراً. </li>
                        </ul>
                    </p>
                    <b>التعويضات :</b></br>
                    <p>
                        بموجب هذا العقد توافق على تعويض فاليو والدفاع عنه وإبعاد الضرر عنه وكل ما من
                        شأنه أن يؤدي إلى إلحاق المسئولية والخسائر بالموقع وكل المسئولين عليه ومديريه ومالكيه
                        ووكلائه والعاملين به ومزوديه بالأخبار والمواضيع وفروعه ومرخصيه والمرخص لهم فيه،
                        وعموما، "الأطراف التي يتم تعويضها" عن كل المساءلات والخسائر التي تلحق به فيما يخص
                        أي ادعاء ناجم عن أي خرق من جهتك لهذا الاتفاق أو لأي شكل من أشكال الاتفاقات والضمانات
                        والتعاقدات المقبلة، بما فيها كل مصاريف قضائية معقولة ناتجة أو لها صلة بأي ادعاء
                        من الادعاءات. ويحتفظ فاليو بالحق، على مسئوليته الخاصة، في تحمل أعباء الدفاع
                        والتقرير في أي مسألة من المسائل التي تتعلق بتعويضك، وبموجب هذا لا يسمح لك في أي
                        ظرف من الظروف التقرير في أي أمر دون التوصل بالموافقة الكتابية من فاليو.
                    </p>
                    <b>إخلاء المسئولية</b></br>
                    <p>
                        يلتزم فاليو بأن كل ما يتوفر به من محتويات وأنظمة معلوماتية ووظائف ومواد ومعلومات
                        مقدمة على الموقع، معروضة "كما هي" حسب أقصى ما يسمح به القانون. ولا يقدم فاليو،
                        ولا أي من توابعه أو فروعه، أي تمثيل أو ضمانات كيفما كانت لها صلة بمحتوى فاليو
                        أو أي من المواد والمعلومات والوظائف القابلة للاستعمال بواسطة الأنظمة المعلوماتية
                        المتوفرة على فاليو. ولا يتحمل فاليو أية مسئولية إزاء أي من المنتوجات أو
                        الخدمات أو الروابط الإلكترونية المتصلة بأطراف أخرى ثالثة، كما لا يتحمل مسئولية أي
                        انتهاك للأمان المرتبط بإرسال معلومات حساسة من خلال فاليو أو أي رابط من روابطه.
                        وفوق ذلك، لا يمنح فاليو أية ضمانات واضحة كانت أو مضمنة، تتعلق، دون استثناء،
                        بعدم القابلية للانتهاك أو سلامة شروط المتاجرة أو الصلاحية المتعلقة بأي أمر من الأمور.
                        ولا يضمن فاليو بأن بيانات العقارات الموجودة على موقعه الإلكتروني أو أي من مواده
                        أو محتوياته خالية من الأخطاء. كما لا يضمن فاليو بأن مثل تلك الأخطاء ستصحح، أو
                        بأن فاليو أو النظام المعلوماتي الذي يعمل من خلاله سيكون خاليا من الفيروسات أو
                        أي شيء ضار. ولن يكون فاليو، أو أي من توابعه أو فروعه، مسئول عن استعمال فاليو،
                        بما في ذلك وبدون استثناء، المحتوى أو أي خطأ من الأخطاء المتواجدة به.
                    </p>
                    <b>الإتفاق الكامل : </b></br>
                    <p>
                        تمثل هذه الاتفاقية عقدًا كاملاً بينك وبين فاليو ( aqarmap.com )، فيما يتعلق
                        باستخدامك لفـ الدليل . وإن أي دعوى ، حول أي تصرف يتعلق باستخدامك فاليو ، يجب
                        أن ترفع خلال شهر من تقديمك الاعتراض، أو من نشوء سبب التصرف المذكور. وإذا اكتشفت
                        المحكمة القضائية المختصة، لأي سبب من الأسباب، عدم إمكانية تنفيذ أي بند من بنود الاتفاقية،
                        أو جزء منها، يتم تطبيق هذا البند بأقصى الحدود الجائزة والمصرح بها، بحيث يتم تنفيذ
                        مغزى الاتفاقية، على أن تبقى جميع الأحكام والبنود الأخرى للاتفاقية نافذة وسارية المفعول.
                        وتتنصل فاليو عن تحمل أية مسئولية، لمضمون مواد أي طرف ثالث، المتوفرة عبر الوصلات
                        و الروابط الموجودة على فاليو او المنشورة بواسطة أعضاء المنتديات.
                    </p>
                    <b>شمولية الاتفاقية</b></br>
                    <p>
                        يحتوي موقع " فاليو " على روابط وإشارات إلى مواقع إنترنت أخرى، ومصادر في مختلف
                        أرجاء العالم، ووصلات بالراعين الرسميين او المعلنين، إن هذه الوصلات التي تصل بين
                        " فاليو " وأي من المواقع الأخرى (وبالعكس)، والتي تدار من قبل طرف ثالث، لا تحمّل
                        " فاليو " أو الطرف الثالث، أي مسئولية، ولا تمثل أي نوع من المصادقة على محتويات
                        تلك المواقع، كما أن " فاليو " غير مسئول عن الآراء ووجهات النظر والأفكار والتصريحات
                        والمعلومات التي تُعرض فيه، أو توزع عبره، وهي لا تمثل وجهة نظر الموقع. ونحيطك علمًا
                        أن أي ركون إلى مثل هذه الآراء والنصائح ووجهات النظر والأفكار والتصريحات والتقارير
                        والمعلومات إنما يجري على مسئوليتك الشخصية. ويحتفظ فاليو بحقه وفق تقديراته الخاصة
                        في تصحيح أية أخطاء أو خلل في أي جزء من موقع "فـ الدليل" ، ولا يقوم موقع "فـ الدليل"
                        ولا يستطيع مراجعة كل المواد المنشورة في صفحاته والتي يسجلها المستخدمون والزوار والأعضاء
                        وبالتالي فإن موقع "فـ الدليل" غير مسئول عن تلك المواد. ويحتفظ موقع " فاليو"
                        بأية حال بحقه الدائم -وعند الضرورة- في كشف أية معلومات من شأنها أن تفيد العدالة
                        والنظام العام ومتطلبات الحكومة وكذلك في تدقيق أو تنقيح أو رفض أو محو أية مواد برمتها
                        أو بجزئياتها والتي يجدها فاليو وفق تقديراته الخاصة، مستهجنة أو تتعارض مع بنود
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
                        فاليو لديه الحق بمنع أو ألغاء دخول المستخدم إلى الموقع أو وقف التعامل مع اي
                        شخص في حاله ثبوت استخدامه الألفاظ النابية ، الفحش ، التهديد ، المضايقة ، التشهيرية
                        ، البغيضه ، المسيئة بأي طريقة كانت أو التعرض بأي شكل من الأشكال تجاه اي موظف في
                        فاليو سوءاً على الموقع ، البريد الألكتروني ، المكالمات التلفونية أو الرسائل
                        ، في الكتابة ، أو في الشخص.
                    </p>
                    <b>إستخدام محتوى الموقع</b></br>
                    <p>
                        يمكنك تحميل ، عرض ، وطباعة نسخة من اي مضمون آخر ، فقط لأغراضك الشخصية وغير التجارية
                        ، ويخضع للقوانين والقيود المنصوص عليها في هذا الأتفاقية "إتفاقية الأستخدام". الأسم
                        ، الشعار ، وكل المحتويات التي تظهر على موقع فاليو ، سوف تظل ملكاً خاصاً لموقع
                        فاليو ومرخصيها. بإستثناء ماهو ماهو مسموح به صراحة في هذا الأتفاق ، ولا يجوز
                        لك استخدام أو تعديل أو إعداد أعمال اشتقاقيه تستند إلى توزيع أو بيع أو نقل أو عرض
                        أو اي طريقة بإستخدام موقع فاليو ، أو اي محتوى ظاهر في موقع فاليو.
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
                        فاليو يقدم/يوفر مجموعة متنوعة من المعلومات وعدد من الأدوات في الموقع لمساعدتك.
                        تعليقات وردود فعل المستخدمين في صفحات معلومات عقارات المستخدمين ، هي جزء من محتويات
                        موقع فاليو من مستخدمي الموقع الذين اختارو إضافة تعليقاتهم وآرائهم على موقع فـ
                        الدليل. في حين تتوفر هذا التعليقات والإضافات للذين يرغبون في الأطلاع عليها ، فأنها
                        لاتعكس رأي إدارة موقع فاليو ولا يضمن أو يؤيد موقع فاليو دقة البيانات في
                        أي نشر على صفحات الموقع. مستخدمي موقع فاليو يجب ان يدركو ان إدارة موقع فاليو
                        لاتساهم في المضمون الوارد في التعليقات والآراء التي تنشر في صفحات الموقع من قبل
                        مستخدمي الموقع.
                    </p>
                    <b>لا ضمانة</b></br>
                    <p>
                        فاليو يتنصل من اي وكافة الضمانات ، التي تتضمن بما في ذالك على سبيل المثال وليس
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
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        اغلاق</button>
                </div>
            </div>
        </div>
    </div>
  
    </form>
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=chkTerms.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</body>
</html>
