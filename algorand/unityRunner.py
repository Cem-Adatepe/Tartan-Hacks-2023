from time import time, sleep

from algosdk import account, encoding
from algosdk.logic import get_application_address
from auction.operations import createAuctionApp, setupAuctionApp, placeBid, closeAuction
from auction.util import (
    getBalances,
    getAppGlobalState,
    getLastBlockTimestamp,
)
from auction.testing.setup import getAlgodClient
from auction.testing.resources import (
    getTemporaryAccount,
    optInToAsset,
    createDummyAsset,
)

if __name__ == "__main__":
  client = getAlgodClient()
  accs = {}
  nfts = {}
  auctions = {}
  while True:
    x = input().split()
    if x[0] == "makeAccount":
      name = x[1]
      accs[name] = getTemporaryAccount(client)
    if x[0] == "makeNft":
      name = x[1]
      creator = x[2]
      amt = x[3]
      nfts[name] = createDummyAsset(client, nftAmount, accs[creator])
    if x[0] == "makeAuction":
      name = x[1]
      creator = x[2]
      seller = x[3]
      nft = x[4]
      add_time = int(x[5])

      startTime = int(time()) + 10
      endTime = startTime + add_time

      reserve = 1_000_000
      increment = 100_000
  
      auctions[name] = createAuctionApp(
        client=client,
        sender=accs[creator],
        seller=accs[seller].getAddress(),
        nftID=nfts[nft],
        startTime=startTime,
        endTime=endTime,
        reserve=reserve,
        minBidIncrement=increment,
      )
    if x[0] == "setupAuction":
      auctionName = x[1]
      seller = x[2]
      creator = x[3]
      nft = x[4]
      setupAuctionApp(
        client=client,
        appID=auctions[auctionName],
        funder=accs[creator],
        nftHolder=acs[seller],
        nftID=nfts[nft],
        nftAmount=1,
      )
    if x[0] == "makeBid":
      auctionName = x[1]
      bidder = x[2]
      bidAmount = int(x[3])
      placeBid(client=client, appID=auctions[auctionName], bidder=accs[bidder], bidAmount=bidAmount)
    if x[0] == "optIn":
      nft = x[1]
      bidder = x[2]
      optInToAsset(client, nfts[nftID], accs[bidder])
    if x[0] == "closeAuction":
      auctionName = x[1]
      seller = x[2]
      closeAuction(client, auctions[auctionName], accs[seller])
