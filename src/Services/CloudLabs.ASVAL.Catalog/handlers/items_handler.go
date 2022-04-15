package handlers

import (
	"log"
	"net/http"
)

type ItemsHandler struct {
	logger *log.Logger
}

func ItemsHandlerConstructor(logger *log.Logger) *ItemsHandler {
	return &ItemsHandler{
		logger: logger,
	}
}

func (ih *ItemsHandler) ServeHTTP(rw http.ResponseWriter, r *http.Request) {

}
