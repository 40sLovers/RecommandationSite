from django.shortcuts import render
from django.http import HttpResponse, JsonResponse


# Create your views here.

def helloWorld(request):
    return HttpResponse("helloWorld")

def jsonResponseExample(request):
    d=dict()
    d["foo"]="bar"
    l=["Film1",[d,"Exemplu"],"Film3"]
    return HttpResponse(JsonResponse(l,safe=False))