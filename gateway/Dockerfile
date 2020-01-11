FROM adoptopenjdk/openjdk11:alpine-jre
RUN mkdir -p /opt/gateway

EXPOSE 33000

COPY target/gateway.jar /opt/gateway

ENTRYPOINT exec java $JAVA_OPTS -jar /opt/gateway/gateway.jar

