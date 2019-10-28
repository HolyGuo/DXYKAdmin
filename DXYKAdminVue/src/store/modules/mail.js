const mail = {
    state: {
        mailId: '',
        draftId: '',
        pageType: '',
        mailType: '',
        target: null,
        senderName: '',
        sendTime: '',
        attachs: null
    },
    mutations: {
        SET_MAIL_ID: (state, mailId) => {
            state.mailId = mailId;
        },
        SET_DRAFT_ID: (state, draftId) => {
            state.draftId = draftId;
        },
        SET_PAGE_TYPE: (state, pageType) => {
            state.pageType = pageType;
        },
        SET_MAIL_TYPE: (state, mailType) => {
            state.mailType = mailType;
        },
        SET_MAIL_SENDER: (state, senderName) => {
            state.senderName = senderName;
        },
        SET_MAIL_SENDTIME: (state, sendTime) => {
            state.sendTime = sendTime;
        },
        SET_MAIL_ATTACH: (state, attachs) => {
            state.attachs = attachs;
        },
    }
}

export default mail;