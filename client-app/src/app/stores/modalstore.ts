import { makeAutoObservable } from "mobx"
import { isConstructorDeclaration, JsxElement } from "typescript"

interface Modal {
    open: boolean;
    body: JSX.Element | null;
}

export default class ModalStore{
    modal: Modal = {
        open: false,
        body: null
    }

    /**
     * store for handling modal
     */
    constructor() {
        makeAutoObservable(this);
    }

    openModal = (content: JSX.Element) => {
        this.modal.open = true;
        this.modal.body = content;
    }

    closeModal = () => {
        this.modal.open = false;
        this.modal.body = null;
    }

}