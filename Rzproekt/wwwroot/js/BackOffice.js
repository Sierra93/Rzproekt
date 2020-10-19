"use strict";

//const hubConnection = new signalR.HubConnectionBuilder()
//	.withUrl("/chat")
//	.build();

//hubConnection.on("Send", function (data) {
//	let elem = document.createElement("p");
//	elem.appendChild(document.createTextNode(data));
//	let firstElem = document.getElementById("chatroom").firstChild;
//	document.getElementById("chatroom").insertBefore(elem, firstElem);

//});

//document.getElementById("sendBtn").addEventListener("click", function (e) {
//	let message = document.getElementById("message").value;
//	hubConnection.invoke("Send", message);
//});

//hubConnection.start();

var back_office = new Vue({
    el: "#back_office",
    data() {
        return {
            files: '',
            filesService: '',
            filesAbout: '',
            filesCert: '',
            filesAwards: '',
            filesClient: '',
            filesProject: '',
            filesDetProject: '',
            filesContact: '',
            filesContactAdd: '',
            date: new Date().getFullYear(),
            notify: '',
            urlApi: 'https://localhost:44349',
            //urlApi: 'https://devmyprojects24.xyz',
            listRequests: [
                '/api/header/get-header',
                '/api/order/get-orders',
                '/api/about/get-about',
                '/api/statistic/get-statistic',
                '/api/project/get-projects',
                '/api/client/get-clients',
                '/api/contact/get-contacts',
                '/api/footer/get-footer',
                '/api/back-office/get-certs'
            ],
            general: {
                detailse: 'Подробнее'
            },
            header: [],
            service: [],
            about: [],
            cert: [],
            arrCertSearth: [],
            arrAwardsSearth: [],
            stat: [],
            project: [],
            arrProjectSearth: [],
            client: [],
            arrClientSearth: [],
            contact: [],
            arrContactsSearth: [],
            footer: []
        }
    },
    update: {

    },
    created() {
        console.log('init');

    },
    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        this.$nextTick(function () {
            let self = this;
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            })

        })
    },
    methods: {
        // Функция собирает файлы header.
        handleFilesUpload() {
            let filesLogo = document.getElementById('filesLogo').files[0];
            let filesVideoBgHeader = document.getElementById('filesVideoBgHeader').files[0];

            if (!!filesLogo) {
                this.files = filesLogo;
            } else if (!!filesVideoBgHeader) {
                this.files = filesVideoBgHeader;
            }
        },
        // Функция собирает файлы услуг.
        handleFilesUploadService() {
            let arrBlocksImg = document.getElementsByClassName('form-files-service');
            this.filesService = arrBlocksImg;
        },
        // Функция собирает файлы о нас.
        handleFilesUploadAbout() {
            let arrBlocksImg = document.getElementsByClassName('form-files-about');
            this.filesAbout = arrBlocksImg;
        },
        // Функция собирает файлы клиенты.
        handleFilesUploadClient() {
            let arrBlocksImg = document.getElementsByClassName('form-files-client');
            this.filesService = arrBlocksImg;
        },
        // Функция собирает файлы о нас (детальная информания).
        handleFilesUploadDetAbout() {
            //let filesAbout = document.getElementsByClassName('form-files-about')[0].files[0];
            let filesDetAbout = document.getElementsByClassName('form-files-det-about')[0].files[0];

            //if (!!filesAbout) {
                //this.filesAbout = filesAbout;
            //} else if (!!filesDetAbout) {
                this.filesAbout = filesDetAbout;
            //}
        },
        // Функция собирает файлы сертификатов.
        handleFilesUploadCert() {
            let filesCert = document.getElementsByClassName('form-files-cert')[0].files;
            this.filesCert = filesCert;
        },
        // Функция собирает файлы наград.
        handleFilesUploadAwards() {
            let filesAwards = document.getElementsByClassName('form-files-awards')[0].files;
            this.filesAwards = filesAwards;
        },
        // Функция собирает файлы клиентов.
        handleFilesUploadClient() {
            let filesClient = document.getElementsByClassName('form-files-client')[0].files;
            this.filesClient = filesClient;
        },
        // Функция собирает файлы проектов.
        handleFilesUploadProject() {
            let filesProject = document.getElementsByClassName('form-files-projectMain')[0].files[0];
            let filesDetProject = document.getElementsByClassName('form-files-project')[0].files[0];
            this.filesProject = filesProject;
            this.filesDetProject = filesDetProject;
        },
        handleFilesUploadContact() {
            let filesContact = document.getElementsByClassName('form-files-contact')[0].files;
            this.filesContact = filesContact;
        },
        handleFilesUploadClientAdd() {
            let filesContactAdd = document.getElementsByClassName('form-files-contactAdd')[0].files;
            this.filesContactAdd = filesContactAdd;
        },
        // Функция оповещений результатов запросов.
        notyfi(e) {
            let blockNotify = document.getElementById('notifications');
            if (e) {
                this.notify = "Данные успешно изменены"
                blockNotify.style.backgroundColor = 'green';
                blockNotify.classList.add('notifications-active');
                function hide() {
                    blockNotify.classList.remove('notifications-active');
                }

                setTimeout(hide, 2000);
            } else {
                this.notify = "Ошибка, данные не изменились"
                blockNotify.style.backgroundColor = 'red';
                blockNotify.classList.add('notifications-active');
                function hide() {
                    blockNotify.classList.remove('notifications-active');
                }
                setTimeout(hide, 2000);
            }

        },

        // Отправляет измененные данные первого блока сайта
        onChangeHeader() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-header';
            let MainItem = $('.header-menu-txt');
            let MainNum = $('.header-menu-num')[0].value;
            let formData = new FormData();

            //formData = formData.get('filesLogo');
            let mainItemArr = [];
            for (let item of MainItem) {
                mainItemArr.push(item.value)
            }

            let MainTitle = $('.header-menu-title')[0].value;

            let oData = {
                MainItem: mainItemArr,
                MainTitle,
                MainNum
            };

            formData.set('filesLogo', this.files);
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);
                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока Услуги
        onChangeService(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-order';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let OrderId = idService + 1;
            let MainTitle = $('.service-main-title')[0].value;
            let Title = $('.service-title')[OrderId-1].value;
            let Text = $('.service-text')[OrderId-1].value;
            
            
            let formData = new FormData();
            let oData = {
                OrderId,
                MainTitle,
                Title,
                Text
            };
            if (!!this.filesService[idService]) {
                formData.set('filesLogo', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
    
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока о нас
        onChangeAbout(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-about';
            let MainTitle = $('.about-Maintitle')[0].value;
            let Text = $('.about-text')[0].value;
            let detMainTitle = $('.about-Det-Maintitle')[0].value;
            let detTitle = $('.about-DetTitle')[0].value;
            let detText = $('.about-detail-text')[0].value;
            let mainImg = !!e.target.getAttribute('id');
            let idService = +e.target.getAttribute('idCustom') - 1;
            let Id = idService + 1;
            let formData = new FormData();
            let oData = {
                Id,
                MainTitle,
                Text,
                detMainTitle,
                detTitle,
                detText,
                mainImg
            };
            if (!!this.filesService[idService]) {
                formData.set('filesAbout', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Поиск Сертификатов
        onSearthCert() {
            let self = this;
            let CertName = document.getElementById("searchCert").value;
            if (!CertName) { self.$data.arrCertSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/about/search';
            let oData = {
                CertName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrCertSearth = []; return}
                    self.$data.arrCertSearth = response.data;
                    console.log("success / getCert", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        // Удаление сертификатов
        onDelCert(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-cert';
            let idCert = +e.target.getAttribute('idCustom');

            try {
                axios.put(sUrl + '?id=' + idCert)
                    .then((response) => {
                        self.onSearthCert();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Добавление сертификатов
        onAddCert() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-cert';
            let nameCert = document.getElementById("nameCert").value;
            let formData = new FormData();
            let oData = {
                nameCert
            }
            if (!!this.filesCert) {
                formData.set('filesCert', this.filesCert[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Поиск Наград
        onSearthAwards() {
            let self = this;
            let AwardsName = document.getElementById("searchAwards").value;
            if (!AwardsName) { self.$data.arrAwardsSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/about/search-awards';
            let oData = {
                AwardsName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrAwardsSearth = []; return }
                    self.$data.arrAwardsSearth = response.data;
                    console.log("success / getAwards", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        onDelAwards(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-awards';
            let idAwards = +e.target.getAttribute('idCustom');

            try {
                axios.put(sUrl + '?id=' + idAwards)
                    .then((response) => {
                        self.onSearthAwards();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Добавление наград
        onAddAwards() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-awards';
            let nameAwards = document.getElementById("nameAwards").value;
            let formData = new FormData();
            let oData = {
                nameAwards
            }
            if (!!this.filesAwards) {
                formData.set('filesAwards', this.filesAwards[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Изменение блока статистики
        onChangeStat() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-stat';
            let nOne = $('.stat-menu-number-one')[0].value;
            let sOne = $('.stat-menu-txt-one')[0].value;
            let nTwo = $('.stat-menu-number-two')[0].value;
            let sTwo = $('.stat-menu-txt-two')[0].value;
            let nThree = $('.stat-menu-number-three')[0].value;
            let sThree = $('.stat-menu-txt-three')[0].value;

            let oData = {
                nOne,
                sOne,
                nTwo,
                sTwo,
                nThree,
                sThree
            }
            //oData = JSON.stringify(oData);
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Поиск проектов
        onSearthProject(e) {
            let self = this;
            let ProjectName = document.getElementById("searchProject").value;
            if (!ProjectName) { self.$data.arrProjectSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/project/all-projects';
            let oData = {
                ProjectName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrProjectSearth = []; return }
                    self.$data.arrProjectSearth = response.data;
                    console.log("success / getProject", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },

        // Изменение Проектов
        onChangeProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-project';
            let MainTitle = $('.project-menu-title')[0].value;
            let detMainTitle = $('.about-Det-Maintitle')[0].value;
            let detTitle = $('.about-DetTitle')[0].value;
            let detText = $('.about-detail-text')[0].value;
            let mainImg = !!e.target.getAttribute('id');
            let idService = +e.target.getAttribute('idCustom') - 1;
            let Id = idService + 1;
            let formData = new FormData();
            let oData = {
                Id,
                MainTitle,
                Text,
                detMainTitle,
                detTitle,
                detText,
                mainImg
            };
            if (!!this.filesService[idService]) {
                formData.set('filesAbout', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }

        },
        // Добавление проектов
        onAddProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-project';
            let nameProject = document.getElementById("nameProject").value;
            let detailProject = document.getElementById("detailProject").value;
            let formData = new FormData();
            let oData = {
                nameProject,
                detailProject
            }

            formData.set('filesProject', this.filesProject);
            // formData.set('filesDetProject', this.filesDetProject[0]);
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Удаление проектов
        onDelProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-project';
            let idCert = +e.target.getAttribute('idCustom');

            try {
                axios.put(sUrl + '?id=' + idCert)
                    .then((response) => {
                        self.onSearthCert();

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Изменение клиентов
        onChangeClient(e) {
            // Отправляет измененные данные блока Client
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-client';
            let MainTitle = $('.client-menu-title')[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;
            let formData = new FormData();
            let oData = {
                ClientId,
                MainTitle
            };
            if (!!this.filesService[idService]) {
                formData.set('filesClient', this.filesService[idService].files[0]);
            }
            
            formData.set('jsonString', JSON.stringify(oData));


            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Поиск клиентов
        onSearthClient() {
            let self = this;
            let ClientName = document.getElementById("searchClient").value;
            if (!ClientName) { self.$data.arrClientSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/client/search';
            let oData = {
                ClientName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrClientSearth = []; return }
                    self.$data.arrClientSearth = response.data;
                    console.log("success / getClient", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },

        // Добваление клиентов
        onAddClient() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-client';
            let nameClient = document.getElementById("nameClient").value;
            let formData = new FormData();
            let oData = {
                nameClient
            }
            if (!!this.filesClient) {
                formData.set('filesClient', this.filesClient[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Удаление Клиентов
        onDelClient(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/delete-client';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;
            let oData = {
                ClientId
            };
            try {
                axios.put(sUrl, oData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Изменение клиентов
        onChangeContact() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-contact';
            let nameContact = document.getElementById("nameContact").value;
            let namePosition = document.getElementById("namePosition").value;
            let telContact = document.getElementById("telContact").value;
            let faxContact = document.getElementById("faxContact").value;
            let emailContact = document.getElementById("emailContact").value;
            let formData = new FormData();
            let oData = {
                nameContact,
                namePosition,
                telContact,
                faxContact,
                emailContact
            }
            if (!!this.filesContact) {
                formData.set('filesContact', this.filesContact[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Поиск контактов
        onSearthContacts() {
            let self = this;
            let ContactName = document.getElementById("searchContact").value;
            if (!ContactName) { self.$data.arrContactSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/contact/search';
            let oData = {
                ContactName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrContactSearth = []; return }
                    self.$data.arrContactSearth = response.data;
                    console.log("success / getContact", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },

        // Удаление клиентов
        onDelContact(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-contact';
            let idContact = +e.target.getAttribute('idCustom');

            try {
                axios.put(sUrl + '?id=' + idContact)
                    .then((response) => {
                        self.onSearthContact();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Добваление клиентов
        onAddContact() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-contact';
            let ContactName = document.getElementById("nameContactAdd").value;
            let PositionName = document.getElementById("namePositionAdd").value;
            let ContactNumber = document.getElementById("telContactAdd").value;
            let ContactFax = document.getElementById("faxContactAdd").value;
            let ContactEmail = document.getElementById("emailContactAdd").value;
            let formData = new FormData();
            let oData = {
                ContactName,
                PositionName,
                ContactNumber,
                ContactFax,
                ContactEmail
            }
            if (!!this.filesContactAdd) {
                formData.set('filesContact', this.filesContactAdd[0]);
            }
            //formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData, oData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;


            try {
                axios.post(sUrl)
                    .then((response) => {
                        switch (response.data[0].block) {
                            case 'header':
                                self.$data.header = response.data;
                                console.log('header получен', response.data);
                                break;
                            case 'service':
                                self.$data.service = response.data;
                                console.log('service получен', response.data);
                                break;
                            case 'about':
                                self.$data.about = response.data;
                                console.log('about получен', response.data);
                                break;
                            case 'cert':
                                self.$data.cert = response.data;
                                console.log('cert получен', response.data);
                                break;
                            case 'stat':
                                self.$data.stat = response.data;
                                console.log('stat получен', response.data);
                                break;
                            case 'project':
                                self.$data.project = response.data;
                                console.log('project получен', response.data);
                                break;
                            case 'client':
                                self.$data.client = response.data;
                                console.log('client получен', response.data);
                                break;
                            case 'contact':
                                self.$data.contact = response.data;
                                console.log('contact получен', response.data);
                                break;
                            case 'footer':
                                self.$data.footer = response.data;
                                console.log('footer получен', response.data);
                                break;
                        }

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onSignIn() {
            let self = this;
            let Login = document.getElementById('login').value;
            let Password = document.getElementById('password').value;
            let sUrl = self.$data.urlApi + '/api/auth/signin';
            let oData = {
                Login,
                Password
            };
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        if (response.data.access_token) window.location.href = self.$data.urlApi + '/back-office';

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        }
    }
});