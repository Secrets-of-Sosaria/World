FROM mono@sha256:34d816779b1248b5cfd095770b64ecbaf1798e2aca693a91c11a018dce9c7ad5 AS base
WORKDIR /app
COPY . .

FROM base as builder
WORKDIR /app/Data/System

RUN mcs -optimize+ \
    -unsafe -t:exe -out:WorldLinux.exe \
    -win32icon:Source/icon.ico -nowarn:219,414 \
    -d:NEWTIMERS -d:NEWPARENT -d:MONO '-recurse:Source/*.cs'

FROM base as runtime
RUN apt update && apt install -y zlib1g zlib1g-dev
COPY --from=builder /app/Data/System/WorldLinux.exe .
ENTRYPOINT [ "mono", "/app/WorldLinux.exe" ]