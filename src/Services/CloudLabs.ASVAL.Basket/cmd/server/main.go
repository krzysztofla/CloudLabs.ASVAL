package main

import (
	"fmt"
	"github.com/gorilla/mux"
	"io/ioutil"
	"net/http"
)

func returnAll(rw http.ResponseWriter, r *http.Request) {
	response, err := ioutil.ReadAll(r.Body)

	if err != nil {
		http.Error(rw, "Ooops", http.StatusBadRequest)
		return
	}

	rw.Header().Set("Content-Type", "application/json")
	//json.NewEncoder(rw).Encode(response)
	rw.Write([]byte(response))
}

func main() {
	router := mux.NewRouter().StrictSlash(true)

	router.HandleFunc("/getSomeData", returnAll).Methods("Post")

	http.ListenAndServe(":8080", router)

	fmt.Println("Welcome to CloudLabs.ASVAL.Basket web api")
}
